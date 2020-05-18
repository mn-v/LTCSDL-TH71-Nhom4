using System;
using System.Collections.Generic;

namespace clothing_store.DAL.Models
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public short? Quantity { get; set; }
        public decimal? Price { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
