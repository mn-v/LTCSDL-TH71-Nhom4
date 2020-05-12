using System;
using System.Collections.Generic;

namespace clothing_store.DAL.Models
{
    public partial class Products
    {
        public Products()
        {
            Carts = new HashSet<Carts>();
            Images = new HashSet<Images>();
            OrderDetails = new HashSet<OrderDetails>();
            Promotion = new HashSet<Promotion>();
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public decimal? OriginalPrice { get; set; }
        public short? Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Description { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<Images> Images { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Promotion> Promotion { get; set; }
    }
}
