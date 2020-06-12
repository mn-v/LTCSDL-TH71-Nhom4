using System;
using clothing_store.Common.DAL;


namespace clothing_store.DAL
{
    using clothing_store.Common.Rsp;
    using clothing_store.DAL.Models;
    using System.Linq;

    public class ContactRep : GenericRep<OnlineStoreContext, Products>
    {

        #region -- methods --


        //Không dùng method add được
        //public SingleRsp CreateContact(Contact contact)
        //{
        //    var res = new SingleRsp();
        //    using (var context = new OnlineStoreContext())
        //    {
        //        using (var tran = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                var t = context.Contact.Add(contact);
        //                context.SaveChanges();
        //                tran.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                tran.Rollback();
        //                res.SetError(ex.StackTrace);
        //            }
        //        }
        //    }
        //    return res;
        //}

        #endregion
    }
}
