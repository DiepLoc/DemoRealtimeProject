using System;
using System.Collections.Generic;
using System.Text;

namespace winform_client.Models
{
    public class PageInfo
    {
        public int PageSize { get; set; } = 4;
        public int Page { get; set; } = 1;
        public int Count { get; set; } = 0;

        public bool IsLast()
        {
            return Page == MaxPage();
        }

        public bool IsFirst()
        {
            return Page == 1;
        }

        public void GoPreviousPage()
        {
            if (!(IsFirst())) Page--;
        }

        public void GoNextPage()
        {
            if (!IsLast()) Page++;
        }

        public int MaxPage()
        {
            return (int)Math.Ceiling((float)Count / PageSize);
        }

        public void checkPageWithDelete()
        {
            Count -= 1;
            if (Page > MaxPage()) Page = MaxPage(); 
        }
    }
}
