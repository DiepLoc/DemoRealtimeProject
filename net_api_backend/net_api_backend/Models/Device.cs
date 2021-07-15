using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace net_api_backend.Models
{
    public partial class Device
    {
        public long Id { get; set; }

        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required]
        [Range(0, 10000)]
        public long Price { get; set; }

        [Required]
        public long BrandId { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
