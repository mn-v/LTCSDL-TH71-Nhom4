using System;
using System.Collections.Generic;

namespace clothing_store.DAL.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }

        public virtual Users User { get; set; }
    }
}
