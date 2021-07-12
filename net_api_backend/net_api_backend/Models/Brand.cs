using System;
using System.Collections.Generic;

#nullable disable

namespace net_api_backend.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Devices = new HashSet<Device>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
