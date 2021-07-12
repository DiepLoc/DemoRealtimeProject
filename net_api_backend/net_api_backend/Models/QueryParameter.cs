using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api_backend.Models
{
    public class QueryParameter
    {
        public int PageSize { get; set; } = 2;
        public int Page { get; set; } = 1;
        public long? BrandId { get; set; } = null;

        public void Deconstruct(out int pageSize, out int page, out long? brandId)
        {
            pageSize = this.PageSize;
            page = this.Page;
            brandId = this.BrandId;
        }
    }
}
