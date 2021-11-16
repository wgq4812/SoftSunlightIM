using System;
using System.Collections.Generic;
using System.Text;

namespace SoftSunlightIM.WebApi.Models
{
    public class PageModel
    {
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
