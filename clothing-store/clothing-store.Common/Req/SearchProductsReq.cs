﻿using System;
using System.Collections.Generic;
using System.Text;

namespace clothing_store.Common.Req
{
    public class SearchProductsReq
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public int id { get; set; }

        public string Type { get; set; }

        public string Keyword { get; set; }
    }
}
