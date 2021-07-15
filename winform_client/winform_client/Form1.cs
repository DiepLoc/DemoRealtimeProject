using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform_client.Api;
using winform_client.Models;

namespace winform_client
{
    public partial class Form1 : Form
    {
        //private List<TabPage> brandTabs = new List<TabPage>();
        private BindingSource bindingSource = new BindingSource();
        private DeviceApi deviceApi;
        private HubApi hubApi;

        private List<Brand> brands;
        private List<Device> devices;

        public Device selectedDevice = null;
        private PageInfo pageInfo = new PageInfo();

        public Form1()
        {
            InitializeComponent();          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource;       
            
            deviceApi = new DeviceApi();
            hubApi = HubApi.GetIntance();
            hubApi.SetCallBack(this.syncData);

            GetBrands();
            GetDevices();
        }

        private async void GetBrands()
        {
            try
            {
                var response = await deviceApi.GetStringAsync("brands");
                brands = JsonConvert.DeserializeObject<List<Brand>>(response);
                brands.ForEach(brand =>
                {
                    TabPage newTabpage = new TabPage();
                    newTabpage.Name = $"tabPage{brand.Id}";
                    newTabpage.Tag = brand.Id;
                    newTabpage.Text = brand.Name;
                    tabControl1.TabPages.Add(newTabpage);
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private async void GetDevices(int page = 1)
        {
            try
            {
                long? brandId = null;
                if (tabControl1.SelectedTab.Tag.ToString() != "all") {
                    brandId = (long)tabControl1.SelectedTab.Tag;
                }
                string stringUrl = "devices?";
                if (brandId != null) stringUrl += $@"&brandid={brandId}";
                stringUrl += $@"&pagesize={pageInfo.PageSize}";
                stringUrl += $@"&page={page}";

                var response = await deviceApi.GetStringAsync(stringUrl);
                var responseObj = JsonConvert.DeserializeObject<dynamic>(response);

                pageInfo = responseObj.pageInfo.ToObject<PageInfo>();
                devices = responseObj.devices.ToObject<List<Device>>();
                devices.ForEach(device =>
                {
                    device.BrandName = device.Brand.Name;
                });
                bindingSource.DataSource = devices;

                dataGridView1.Columns["BrandName"].HeaderText = "Brand";
                dataGridView1.Columns["brandId"].Visible = false;
                dataGridView1.Columns["brand"].Visible = false;

                selectedDevice = null;
                if (dataGridView1.SelectedRows.Count >= 0)
                {
                    dataGridView1.SelectedRows[0].Selected = false;
                }

                ToggleEditAndRemove(false);
                changePage();
            }
            catch(Exception ex)
            {
 
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ToggleEditAndRemove(bool enable = true)
        {
            btnDelete.Enabled = enable;
            btnEdit.Enabled = enable;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (!(indexRow >= 0)) return;

            long selectedID = (long)dataGridView1.Rows[indexRow].Cells["Id"].Value;
            selectedDevice = Device.Clone(devices.First(d => d.Id == selectedID));

            ToggleEditAndRemove();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ModalDevice modal = new ModalDevice(brands, this);
            modal.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            selectedDevice = null;
            ModalDevice modal = new ModalDevice(brands, this);
            modal.ShowDialog();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure to delete this item ?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await deviceApi.DeleteAsync(selectedDevice.Id);
                    selectedDevice = null;

                    ToggleEditAndRemove(false);

                    pageInfo.checkPageWithDelete();
                    GetDevices(page: pageInfo.Page);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public async Task<bool> OnAddOrEdit()
        {
            try
            {
                if (selectedDevice.Id == 0) await onAddDevice();
                else await onEditDevice();

                //GetDevices(page: pageInfo.Page, pageSize: pageInfo.PageSize);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }           
        }

        private async Task onAddDevice()
        {
            await deviceApi.PostAsJsonAsync(selectedDevice);
        }

        private async Task onEditDevice()
        {
            await deviceApi.PutAsJsonAsync(selectedDevice.Id, selectedDevice);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDevices();       
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            GetDevices(page: pageInfo.Page + 1);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            GetDevices(page: pageInfo.Page - 1);
        }

        private void changePage()
        {
            btnNext.Enabled = !pageInfo.IsLast();
            btnPrevious.Enabled = !pageInfo.IsFirst();

            labelPage.Text = @$"{pageInfo.Page}/{pageInfo.MaxPage()}";
        }

        public void syncData(string message = "")
        {
            GetDevices(page: pageInfo.Page);

            string newTopLine = "- The data has been updated";
            if (!string.IsNullOrEmpty(message)) newTopLine = message + '\n';

            richTextBox1.Text = newTopLine + richTextBox1.Text;
        }
    }
}
