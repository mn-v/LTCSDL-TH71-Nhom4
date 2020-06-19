using clothing_store.Common.DAL;
using clothing_store.Common.Rsp;
using clothing_store.DAL.Models;
using System;
using System.Linq;

namespace clothing_store.DAL
{
    public class PromotionRep : GenericRep<OnlineStoreContext, Promotion>
    {
        #region -- Override --
        public override Promotion Read(int id)
        {
            var res = All.FirstOrDefault(p => p.PromotionId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.FirstOrDefault(p => p.PromotionId == id);
            m = base.Delete(m);
            return m.PromotionId;
        }
        #endregion

        #region -- Methods --

        public SingleRsp CreatePromotion(Promotion promotion)
        {
            var res = new SingleRsp();
            using (var context = new OnlineStoreContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Promotion.Add(promotion);
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

        public SingleRsp UpdatePromotion(Promotion promotion)
        {
            var res = new SingleRsp();
            using (var context = new OnlineStoreContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Promotion.Update(promotion);
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

        public int DeletePromotion(int id)
        {
            var res = 0;
            var context = new OnlineStoreContext();
            var promotion = base.All.FirstOrDefault(p => p.PromotionId == id);
            if (promotion != null)
            {
                context.Promotion.Remove(promotion);
                res = context.SaveChanges();
            }
            return res;
        }

        #endregion

    }
}
