using System;
using System.Collections.Generic;
using System.Text;

namespace clothing_store.Common.Req
{
    class CategoriesReq
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsShowOnHome { get; set; }
        public int? ParentId { get; set; }
        public string Status { get; set; }

    }
}
