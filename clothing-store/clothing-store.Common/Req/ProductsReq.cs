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
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public DateTime DateCreate { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public int? PromotionId { get; set; }
    }
}
