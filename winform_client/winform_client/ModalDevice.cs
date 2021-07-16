using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using winform_client.Models;

namespace winform_client
{
    public partial class ModalDevice : Form
    {
        private List<Brand> brands;
        private Form1 form1;

        public ModalDevice(List<Brand> brands, Form1 form1)
        {
            InitializeComponent();

            Text = form1.selectedDevice == null ? "Create device" : "Edit device";

            this.form1 = form1;
            this.brands = brands;
        }

        private void ModalDevice_Load(object sender, EventArgs e)
        {
            if (form1.selectedDevice != null) OnLoadEdit();
            else OnLoadCreate();
        }

        private void OnLoadEdit()
        {           
            txtName.Text = form1.selectedDevice.Name;
            numberPrice.Value = form1.selectedDevice.Price;

            comboBrand.DataSource = brands;
            comboBrand.DisplayMember = "Name";
            comboBrand.ValueMember = "Id";
            comboBrand.SelectedValue = form1.selectedDevice.BrandId;
        }
        private void OnLoadCreate()
        {
            txtName.Text = string.Empty;
            numberPrice.Value = 0;
            comboBrand.DataSource = brands;
            comboBrand.DisplayMember = "Name";
            comboBrand.ValueMember = "Id";
        }

        private bool ValidateInput()
        {
            if (comboBrand.SelectedIndex < 0)
            {
                MessageBox.Show("Choose brand");
                return false;
            }
            if (txtName.Text.Trim() == string.Empty) { 
                MessageBox.Show("Name is required");
                return false;
            }
            return true;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (form1.selectedDevice == null) form1.selectedDevice = new Device();

            form1.selectedDevice.BrandId = (long)comboBrand.SelectedValue;
            form1.selectedDevice.Name = txtName.Text;
            form1.selectedDevice.Price = (long)numberPrice.Value;

            SetLoading();
            bool isSuccess = await form1.OnAddOrEdit();

            SetLoading(false);
            if (isSuccess) this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetLoading(bool loading = true)
        {
            form1.SafeCallbackControl(labelLoading, 
                () => labelLoading.Text = loading 
                ? "Processing, wait..." 
                : string.Empty);
            form1.SafeCallbackControl(this, () => this.Enabled = !loading);
        }
    }
}
