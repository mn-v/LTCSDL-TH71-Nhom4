using System;
using System.Collections.Generic;

namespace clothing_store.DAL.Models
{
    public partial class RoleUser
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }

        public virtual Role User { get; set; }
        public virtual Users UserNavigation { get; set; }
    }
}
