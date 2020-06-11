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

        //Product-Sale
        public object GetSP_ProductSale()
        {
            var emp = Context.Products
                .Join(Context.Promotion, a => a.PromotionId, b => b.PromotionId, (a, b) => new
                {
                    a.ProductId,
                    a.ProductName,
                    a.Price,
                    a.Description,
                    b.DiscountPercent,
                    a.ImageSource
                }).ToList();
            var res = emp.GroupBy(x => x.ProductId)
                .Select(x => new
                {
                    ProductID = x.First().ProductId,
                    ProductName = x.First().ProductName,
                    Price = x.First().Price,
                    Description = x.First().Description,
                    DiscountPercent = x.First().DiscountPercent,
                    ImageSource = x.First().ImageSource

                }).ToList();
            return res;
        }

        //Product-Accessories
        public object GetSP_ProductAccessories()
        {
            var emp = Context.Products
                .Join(Context.Categories, a => a.CategoryId, b => b.CategoryId, (a, b) => new
                {
                    a.ProductId,
                    a.ProductName,
                    a.Price,
                    a.Description,
                    a.ImageSource,
                    a.PromotionId
                })
                .Join(Context.Promotion, a => a.PromotionId, b => b.PromotionId, (a, b) => new
                {
                    a.ProductId,
                    a.ProductName,
                    a.Price,
                    a.Description,
                    a.ImageSource,
                    b.DiscountPercent
                }).Where(x => x.ProductName.Contains("Phụ kiện")).ToList();
            var res = emp.GroupBy(x => x.ProductId)
                .Select(x => new
                {
                    ProductID = x.First().ProductId,
                    ProductName = x.First().ProductName,
                    Price = x.First().Price,
                    Description = x.First().Description,
                    ImageSource = x.First().ImageSource,
                    DiscountPercent = x.First().DiscountPercent

                }).ToList();
            return res;
        }

        #endregion
    }
}
