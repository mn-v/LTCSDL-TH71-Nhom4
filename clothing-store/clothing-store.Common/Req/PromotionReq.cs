using System;
using System.Collections.Generic;
using System.Text;

namespace clothing_store.Common.Req
{
    public class PromotionReq
    {
        public int PromotionId { get; set; }
        public string PromotionName { get; set; }
        public float DiscountPercent { get; set; }
    }
}
