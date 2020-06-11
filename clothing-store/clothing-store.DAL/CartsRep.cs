using System;
using clothing_store.Common.DAL;


namespace clothing_store.DAL
{
    using clothing_store.Common.Rsp;
    using clothing_store.DAL.Models;
    using System.Linq;

    public class CartsRep : GenericRep<OnlineStoreContext, Carts>
    {
        #region -- override --
        public override Carts Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CartId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.FirstOrDefault(p => p.CartId == id);
            m = base.Delete(m);
            return m.CartId;
        }

        #endregion
        #region -- methods --

        //Tạo - Chia làm 2 trường hợp
        public SingleRsp CreateCart(Carts carts)
        {
            var res = new SingleRsp();
            if (Context.Carts.Where(x => x.ProductId == carts.ProductId).ToList().Count != 0 && (Context.Carts.Where(x => x.Size == carts.Size).ToList().Count != 0))
               {
                   carts.Size += Context.Carts.Where(x => x.Size == carts.Size).ToList().First().Size;
                   res = UpdateCart(carts);
               }
            else
                    using (var context = new OnlineStoreContext())
                {
                    using (var tran = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var t = context.Carts.Add(carts);
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

        //Update
        public SingleRsp UpdateCart(Carts carts)
        {
            var res = new SingleRsp();
            
                using (var context = new OnlineStoreContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Carts.Update(carts);
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

        //Xóa
        public SingleRsp DeleteCart(int ProductId)
        {
            var res = new SingleRsp();
            var list = Context.Carts
               .Where(x => x.ProductId == ProductId).ToList();
            Carts carts = list.First();
            using (var context = new OnlineStoreContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Carts.Remove(carts);
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

        #endregion
    }
}
