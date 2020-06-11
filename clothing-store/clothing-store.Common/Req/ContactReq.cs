using System;
using System.Collections.Generic;
using System.Text;

namespace clothing_store.Common.Req
{
    public class ContactReq
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
