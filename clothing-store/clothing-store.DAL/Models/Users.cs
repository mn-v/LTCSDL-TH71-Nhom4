using System;
using System.Collections.Generic;

namespace clothing_store.DAL.Models
{
    public partial class Users
    {
        public Users()
        {
            Carts = new HashSet<Carts>();
            Contact = new HashSet<Contact>();
            Orders = new HashSet<Orders>();
            RoleUser = new HashSet<RoleUser>();
            Transactions = new HashSet<Transactions>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<RoleUser> RoleUser { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
