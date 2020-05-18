﻿using System;
using System.Collections.Generic;

namespace clothing_store.DAL.Models
{
    public partial class Carts
    {
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public short? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? UserId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}