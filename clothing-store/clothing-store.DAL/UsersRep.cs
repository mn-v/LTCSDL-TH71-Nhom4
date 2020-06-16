using clothing_store.Common.DAL;
using clothing_store.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace clothing_store.DAL
{
    public class UsersRep : GenericRep<OnlineStoreContext, Users>
    {
        public override Users Read(int id)
        {
            var res = All.FirstOrDefault(u => u.UserId == id);
            return res;
        }

        public object CheckAcc(String user, String pass)
        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                var cmd = cnn.CreateCommand();

                cmd.CommandText = "[CheckAcc]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            RoleID = row["RoleID"],         
                        };
                        res.Add(x);
                    }
                }
            }
            catch (Exception ex)
            {
                res = null;
            }

            return res;
        }

    }
}
