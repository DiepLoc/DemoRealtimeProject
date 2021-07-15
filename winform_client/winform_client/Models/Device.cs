using System;
using System.Collections.Generic;
using System.Text;

namespace winform_client.Models
{
    public class Device
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public long BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual Brand Brand { get; set; }

        static public Device Clone(Device device)
        {
            Device clone = new Device();
            clone.Id = device.Id;
            clone.Name = device.Name;
            clone.Price = device.Price;
            clone.BrandId = device.BrandId;
            clone.Brand = device.Brand;
            clone.BrandName = device.BrandName;
            return clone;
        }
    }
}
