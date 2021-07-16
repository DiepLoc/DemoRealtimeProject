using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform_client.Api;
using winform_client.Models;

namespace winform_client
{
    public partial class Form1 : Form
    {
        private delegate void SafeAddTabControlDelegate(Control control, Action action);
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
            ConfigHubApi();

            ReloadData();
        }

        private void ReloadData()
        {
            if (tabControl1.TabPages.Count < 2) GetBrands();
            GetDevices();
        }

        private void ConfigHubApi()
        {
            hubApi = HubApi.GetIntance();
            hubApi.SetCallBack(this.SyncData);
            hubApi.SetErrorCallback(() => {
                MessageBox.Show("Connection to hubs interrupted, can't get Real time sync");
                SetControlTextSafeThread(
                    richTextHubs, 
                    "Trying to reconnect to hubs");
            });

            hubApi.SetReconnectedCallback(() =>
            {
                MessageBox.Show("Reconnection to hubs is successful, data sync is enabled");
                SetControlTextSafeThread(
                    richTextHubs, 
                    "Reconnect to hubs successfully");
                ReloadData();
            });
            hubApi.SetFirstConnectCallback(() =>
            {
                SetControlTextSafeThread(
                    richTextHubs,
                    "Connect to hubs successfully");
                ReloadData();
            });
        }

        private async Task<T> GetConvertDataAsync<T>(string strinUrl)
        {
            var response = await deviceApi.GetStringAsync(strinUrl);
            return JsonConvert.DeserializeObject<T>(response);
        }

        public void SafeCallbackControl(Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                var d = new SafeAddTabControlDelegate(SafeCallbackControl);
                control.Invoke(d, new object[] { control, action });
            }
            else
            {
                action();
            }
        }

        public void SetControlTextSafeThread(Control control, string text)
        {
            SafeCallbackControl(control, () => control.Text = text);
        }

        private async void GetBrands()
        {
            try
            {
                brands = await GetConvertDataAsync<List<Brand>>("brands");
                brands.ForEach(brand =>
                {
                    TabPage newTabpage = new TabPage();
                    newTabpage.Name = $"tabPage{brand.Id}";
                    newTabpage.Tag = brand.Id;
                    newTabpage.Text = brand.Name;
                    SafeCallbackControl(tabControl1, () =>
                    {
                        tabControl1.TabPages.Add(newTabpage);
                    });
                });
            }
            catch(Exception ex)
            {
            }
        }

        private async void GetDevices(int page = 1)
        {
            try
            {
                string stringUrl = "devices?";

                stringUrl += $@"&pagesize={pageInfo.PageSize}";
                stringUrl += $@"&page={page}";
                if (tabControl1.SelectedTab.Tag.ToString() != "all") {
                    var brandId = (long)tabControl1.SelectedTab.Tag;
                    stringUrl += $@"&brandid={brandId}";
                }

                DeviceListData data = await GetConvertDataAsync<DeviceListData>(stringUrl);
                pageInfo = data.PageInfo;
                devices = data.Devices;

                devices.ForEach(device =>
                {
                    device.BrandName = device.Brand.Name;
                });

                bindingSource.DataSource = devices;

                SafeCallbackControl(dataGridView1, () => { 
                    dataGridView1.Columns["BrandName"].HeaderText = "Brand";
                    dataGridView1.Columns["brandId"].Visible = false;
                    dataGridView1.Columns["brand"].Visible = false;
                    if (dataGridView1.SelectedRows.Count >= 0)
                    {
                        dataGridView1.SelectedRows[0].Selected = false;
                    }
                });

                selectedDevice = null;
                ToggleEditAndRemove(false);
                ChangePage();
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
            if (indexRow < 0) return;

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
            var result = MessageBox.Show(
                "Are you sure to delete this item ?",
                "Confirm Delete!!",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    SetLoading();
                    await deviceApi.DeleteAsync(selectedDevice.Id);

                    selectedDevice = null;
                    pageInfo.CheckPageWithDelete();
                    SetLoading(false);
                    ToggleEditAndRemove(false);
                    GetDevices(page: pageInfo.Page);
                }
                catch (Exception ex)
                {
                    SetLoading(false);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SetLoading(bool loading = true)
        {
            if (loading) SetControlTextSafeThread(labelMessage, "Processing, please wait...");
            else SetControlTextSafeThread(labelMessage, string.Empty);

            SafeCallbackControl(this, () => this.Enabled = !loading);
        }


        public async Task<bool> OnAddOrEdit()
        {
            try
            {
                SetLoading();
                if (selectedDevice.Id == 0) await OnAddDevice();
                else await OnEditDevice();

                GetDevices(page: pageInfo.Page);
                SetLoading(false);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                SetLoading(false);
                return false;
            }           
        }

        private async Task OnAddDevice()
        {
            await deviceApi.PostAsJsonAsync(selectedDevice);
        }

        private async Task OnEditDevice()
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

        private void ChangePage()
        {
            btnNext.Enabled = !pageInfo.IsLast();
            btnPrevious.Enabled = !pageInfo.IsFirst();

            labelPage.Text = @$"{pageInfo.Page}/{pageInfo.MaxPage()}";
        }

        public void SyncData(string message = "")
        {
            GetDevices(page: pageInfo.Page);

            string newTopLine = "- The data has been updated";
            if (!string.IsNullOrEmpty(message)) newTopLine = message + '\n';

            SetControlTextSafeThread(richTextBox1, newTopLine + richTextBox1.Text);
        }

        private void btnReconnect_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
        
    }
}
