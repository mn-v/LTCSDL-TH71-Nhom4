using System;
using System.Collections.Generic;

namespace clothing_store.DAL.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsShowOnHome { get; set; }
        public int? ParentId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
