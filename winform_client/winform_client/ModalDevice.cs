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
            if (form1.selectedDevice != null) onLoadEdit();
            else onLoadCreate();
        }

        private void onLoadEdit()
        {           
            txtName.Text = form1.selectedDevice.Name;
            numberPrice.Value = form1.selectedDevice.Price;

            comboBrand.DataSource = brands;
            comboBrand.DisplayMember = "Name";
            comboBrand.ValueMember = "Id";
            comboBrand.SelectedValue = form1.selectedDevice.BrandId;
        }
        private void onLoadCreate()
        {
            txtName.Text = "";
            numberPrice.Value = 0;
            comboBrand.DataSource = brands;
            comboBrand.DisplayMember = "Name";
            comboBrand.ValueMember = "Id";
        }

        private bool validateInput()
        {
            if (!(comboBrand.SelectedIndex >= 0))
            {
                MessageBox.Show("Choose brand");
                return false;
            }
            if (txtName.Text.Trim() == "") { 
                MessageBox.Show("Name is required");
                return false;
            }
            return true;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!validateInput()) return;

            if (form1.selectedDevice == null) form1.selectedDevice = new Device();

            form1.selectedDevice.BrandId = (long)comboBrand.SelectedValue;
            form1.selectedDevice.Name = txtName.Text;
            form1.selectedDevice.Price = (long)numberPrice.Value;

            bool isSuccess = await form1.OnAddOrEdit();

            if (isSuccess) this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
