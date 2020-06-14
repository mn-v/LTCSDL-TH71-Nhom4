using System;
using System.Collections.Generic;
using System.Text;
using clothing_store.Common.DAL;

namespace clothing_store.DAL
{
    using clothing_store.Common.Rsp;
    using clothing_store.DAL.Models;
    using System.Collections;
    using System.Linq;

    // day la lop dai dien cho doi tuong Categories
    public class CategoriesRep : GenericRep<OnlineStoreContext, Categories>
    {
        #region -- Overrides --
        public override Categories Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CategoryId == id);
            return res; // thay vi ghi base.All thi ghi All no cung hieu
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m);
            return m.CategoryId;
        }
        #endregion

        #region -- methods --

        public SingleRsp CreateCategory(Categories categories)
        {
            var res = new SingleRsp();
            using (var context = new OnlineStoreContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Categories.Add(categories);
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

        public SingleRsp UpdateCategory(Categories categories)
        {
            var res = new SingleRsp();
            using (var context = new OnlineStoreContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Categories.Update(categories);
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

        public int DeleteCategory(int id)
        {
            var res = 0;
            var context = new OnlineStoreContext();
            var category = base.All.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                context.Categories.Remove(category);
                res = context.SaveChanges();
            }
            return res;
        }

        #endregion

        public object GetCategoryNameByGender_Linq(bool gender)
        {
            var res = Context.Categories
                .Where(x => x.Gender == gender)
                .Select(p => new { p.CategoryName }).ToList();
            return res;
        }
       
    }
}
