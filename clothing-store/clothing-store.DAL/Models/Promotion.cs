using System;
using System.Collections.Generic;

namespace clothing_store.DAL.Models
{
    public partial class Promotion
    {
        public int PromotionId { get; set; }
        public string PromotionName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? ApplyForAll { get; set; }
        public float? DiscountPercent { get; set; }
        public float? DiscountAmount { get; set; }
        public int? ProductIds { get; set; }
        public int? ProductCategoryIds { get; set; }
        public string Status { get; set; }

        public virtual Products ProductIdsNavigation { get; set; }
    }
}
