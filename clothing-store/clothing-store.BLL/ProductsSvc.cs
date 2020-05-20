using System;
using System.Collections.Generic;
using System.Text;

namespace clothing_store.Common.Req
{
    public class ProductsReq
    {
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
    }
}
