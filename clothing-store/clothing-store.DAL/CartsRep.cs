using System;
using clothing_store.Common.DAL;


namespace clothing_store.DAL
{
    using clothing_store.Common.Rsp;
    using clothing_store.DAL.Models;
    using System.Linq;

    public class CartsRep : GenericRep<OnlineStoreContext, Carts>
    {
        #region -- Override --
        public override Carts Read(int id)
        {
            var res = All.FirstOrDefault(p => p.UserId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.FirstOrDefault(p => p.UserId == id);
            m = base.Delete(m);
            return m.UserId;
        }
        #endregion

        #region -- Methods --

        //Tạo - Chia làm 2 trường hợp
        public SingleRsp CreateCart(Carts carts)
        {
            var res = new SingleRsp();
            if (Context.Carts.Where(x => x.UserId == carts.UserId).ToList().Count != 0 && Context.Carts.Where(x => x.ProductId == carts.ProductId).ToList().Count != 0 && (Context.Carts.Where(x => x.Size == carts.Size).ToList().Count != 0))
            {
                carts.Quantity += Context.Carts.Where(x => x.Size == carts.Size).ToList().FirstOrDefault().Quantity;
                res = UpdateCart(carts.UserId, carts.Size, carts.Quantity);
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

        //Update -- chỉ sửa size và số lượng
        public SingleRsp UpdateCart(int UserId, string Size, short Quantity)
        {
            var res = new SingleRsp();
            
            using (var context = new OnlineStoreContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        Carts carts = Context.Carts.Where(x => x.UserId == UserId).ToList().FirstOrDefault();
                        carts.Size = Size;
                        carts.Quantity = Quantity;
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
        public SingleRsp DeleteCart(int userId)
        {
            var res = new SingleRsp();
            var list = Context.Carts
               .Where(x => x.UserId == userId).ToList();
            
                
                using (var context = new OnlineStoreContext())
                {
                    using (var tran = context.Database.BeginTransaction())
                    {
                        try
                        {
                            foreach (Carts cart in list)
                            {
                                var t = context.Carts.Remove(cart);
                                context.SaveChanges();
                                tran.Commit();
                            }
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

        //Tìm kiếm
        public object FindCart(int userId)
        {
            var list = Context.Carts
               .Where(x => x.UserId == userId).ToList();
            return list;
        }

        #endregion
    }
}
