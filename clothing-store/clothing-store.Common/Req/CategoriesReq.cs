using System;
using System.Collections.Generic;
using System.Text;

namespace clothing_store.Common.Req
{
    public class CategoriesReq
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Gender { get; set; }

    }
}
