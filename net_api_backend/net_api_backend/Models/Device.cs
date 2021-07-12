using System;
using System.Collections.Generic;

#nullable disable

namespace net_api_backend.Models
{
    public partial class Device
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public long BrandId { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
