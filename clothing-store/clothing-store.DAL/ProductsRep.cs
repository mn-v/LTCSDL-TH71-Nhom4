
using System;
using clothing_store.Common.DAL;


namespace clothing_store.DAL
{
    using clothing_store.Common.Rsp;
    using clothing_store.DAL.Models;
    using System.Linq;

    public class ProductsRep : GenericRep<OnlineStoreContext, Products>
    {
        #region -- override --
        public override Products Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.FirstOrDefault(p => p.ProductId == id);
            m = base.Delete(m);
            return m.ProductId;
        }
        #endregion
        #region -- methods --

        //lay tat ca san pham cua nam hoac nu, nu la true, nam la false
        public object GetAllProductByGender_Linq(bool gender)
        {
            var res = Context.Products
                .Join(Context.Categories, a => a.CategoryId, b => b.CategoryId, (a, b) => new
                {
                    a.ProductId,
                    a.CategoryId,
                    a.ProductName,
                    a.Price,
                    a.Stock,
                    a.DateCreate,
                    a.Description,
                    a.ImageSource,
                    a.PromotionId,
                    b.Gender
                }).Where(x => x.Gender == gender).ToList();
            return res;
        }

        //lay san pham theo loai san pham 
        public object GetProductByCategoryId_Linq(int categoryId)
        {
            var res = Context.Products
                .Join(Context.Categories, a => a.CategoryId, b => b.CategoryId, (a, b) => new
                {
                    a.ProductId,
                    a.CategoryId,
                    a.ProductName,
                    a.Price,
                    a.Stock,
                    a.DateCreate,
                    a.Description,
                    a.ImageSource,
                    a.PromotionId
                }).Where(x => x.CategoryId == categoryId).ToList();
            return res;
        }

        //lay san pham co khuyen mai theo gioi tinh 
        public object GetProductByPromotion_Linq(bool gender)
        {
            var res = Context.Products
                .Join(Context.Categories, a => a.CategoryId, b => b.CategoryId, (a, b) => new
                {
                    a.ProductId,
                    a.CategoryId,
                    a.ProductName,
                    a.Price,
                    a.Stock,
                    a.DateCreate,
                    a.Description,
                    a.ImageSource,
                    a.PromotionId,
                    b.Gender
                }).Where(x => x.Gender == gender && x.PromotionId > 0).ToList();
            return res;
        }

        public SingleRsp CreateProduct(Products products)
        {
            var res = new SingleRsp();
            using (var context = new OnlineStoreContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Products.Add(products);
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

        public SingleRsp UpdateProduct(Products pro)
        {
            var res = new SingleRsp();
            using (var context = new OnlineStoreContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Products.Update(pro);
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

        public int DeleteProduct(int id)
        {
            var res = 0;
            var context = new OnlineStoreContext();
            var pro = base.All.FirstOrDefault(p => p.ProductId == id);
            if(pro != null)
            {
                context.Products.Remove(pro);
                res = context.SaveChanges();
            }
            return res;
        }

        #endregion
    }
}
