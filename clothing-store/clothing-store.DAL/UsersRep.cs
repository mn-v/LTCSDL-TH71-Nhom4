using clothing_store.Common.DAL;
using clothing_store.Common.Rsp;
using clothing_store.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace clothing_store.DAL
{
    public class UsersRep : GenericRep<OnlineStoreContext, Users>
    {
        public override Users Read(int id)
        {
            var res = All.FirstOrDefault(u => u.UserId == id);
            return res;
        }
        public SingleRsp CreateUser(Users users)
        {
            var res = new SingleRsp();
            using (var context = new OnlineStoreContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Users.Add(users);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public object CheckAcc_Linq(String username, String password)
        {
            var res = Context.Users
                .Where(x => x.UserName == username && x.Password == password)
                .Select(u => new { u.RoleId }).ToList();
            return res;
        }
     

    }
}
