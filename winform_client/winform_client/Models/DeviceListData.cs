using System;
using System.Collections.Generic;
using System.Text;

namespace winform_client.Models
{
    class DeviceListData
    {
        public List<Device> Devices { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
