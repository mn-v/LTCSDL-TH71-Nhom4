
using System;
using clothing_store.Common.Rsp;
using clothing_store.Common.BLL;
using clothing_store.Common.Req;
using clothing_store.DAL.Models;
using clothing_store.DAL;
using System.Linq;

namespace clothing_store.BLL
{
    public class ProductsSvc : GenericSvc<ProductsRep, Products>
    {
        //#region -- Overrides --
        //public override SingleRsp Read(int id)
        //{
        //    var res = new SingleRsp();

        //    var m = _rep.Read(id);
        //    res.Data = m;

        //    return res;
        //}

        //public override SingleRsp Update(Products m)
        //{
        //    var res = new SingleRsp();

        //    var m1 = m.ProductId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductId);
        //    if (m1 == null)
        //    {
        //        res.SetError("EZ103", "No data.");
        //    }
        //    else
        //    {
        //        res = base.Update(m);
        //        res.Data = m;
        //    }

        //    return res;
        //}



        //#endregion

        //#region -- Methods --


        //public object getProductById(int id)
        //{
        //    var pro = All.FirstOrDefault(x => x.ProductId == id);
        //    var sup = _rep.Context.Products.FirstOrDefault(x => x.ProductId == pro.ProductId);
        //    var product = new
        //    {
        //        pro.ProductId,
        //        pro.ProductName,
        //        pro.Category.CategoryName,
        //        pro.Price,
        //        pro.OriginalPrice,
        //        pro.Stock,
        //        pro.ViewCount,
        //        pro.DateCreate,
        //        pro.Description,
        //        pro.SeoDescription,
        //        pro.SeoTitle
        //    };
        //    return pro;
        //}

        //public object SearchProduct(String keyword, int page, int size)
        //{
        //    var pro = All.Where(x => x.ProductName.Contains(keyword));

        //    var offset = (page - 1) * size;
        //    var total = pro.Count();
        //    int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
        //    var data = pro.OrderBy(x => x.ProductName).Skip(offset).Take(size).ToList();

        //    var res = new
        //    {
        //        Data = data,
        //        TotalRecord = total,
        //        TotalPages = totalPages,
        //        Page = page,
        //        Size = size
        //    };
        //    return res;
        //}

        //public SingleRsp CreateProduct(ProductsReq pro)
        //{
        //    var res = new SingleRsp();
        //    Products products = new Products();
        //    products.ProductId = pro.ProductId;
        //    products.ProductName = pro.ProductName;
        //    products.Price = pro.Price;
        //    products.OriginalPrice = pro.OriginalPrice;
        //    products.Stock = pro.Stock;
        //    products.ViewCount = pro.ViewCount;
        //    products.DateCreate = pro.DateCreate;
        //    products.Description = pro.Description;
        //    products.SeoDescription = pro.SeoDescription;
        //    products.SeoTitle = pro.SeoTitle;
        //    res = _rep.CreateProduct(products);
        //    return res;
        //}

        //public SingleRsp UpdateProduct(ProductsReq pro)
        //{
        //    var res = new SingleRsp();
        //    Products products = new Products();
        //    products.ProductId = pro.ProductId;
        //    products.ProductName = pro.ProductName;
        //    products.Price = pro.Price;
        //    products.OriginalPrice = pro.OriginalPrice;
        //    products.Stock = pro.Stock;
        //    products.ViewCount = pro.ViewCount;
        //    products.DateCreate = pro.DateCreate;
        //    products.Description = pro.Description;
        //    products.SeoDescription = pro.SeoDescription;
        //    products.SeoTitle = pro.SeoTitle;
        //    res = _rep.UpdateProduct(products);
        //    return res;
        //}

       

        //public ProductsSvc()
        //{

        //}
           

        //#endregion

    }
}
