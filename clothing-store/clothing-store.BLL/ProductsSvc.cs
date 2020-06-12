
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
        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public override SingleRsp Update(Products m)
        {
            var res = new SingleRsp();

            var m1 = m.ProductId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductId);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }

        #endregion

        #region -- Methods --


        public object SearchProduct(String keyword, int page, int size)
        {
            var pro = All.Where(x => x.ProductName.Contains(keyword));

            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = pro.OrderBy(x => x.ProductName).Skip(offset).Take(size).ToList();

            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPages,
                Page = page,
                Size = size
            };
            return res;
        }
        
        public SingleRsp CreateProduct(ProductsReq pro)
        {
            var res = new SingleRsp();
            Products products = new Products();
            products.ProductId = pro.ProductId;
            products.CategoryId = pro.CategoryId;
            products.ProductName = pro.ProductName;
            products.Price = pro.Price;
            products.Stock = pro.Stock;
            products.DateCreate = pro.DateCreate;
            products.Description = pro.Description;
            products.ImageSource = pro.ImageSource;
            products.PromotionId = pro.PromotionId;

            res = _rep.CreateProduct(products);
            return res;
        }

        public SingleRsp UpdateProduct(ProductsReq pro)
        {
            var res = new SingleRsp();
            Products products = new Products();
            products.ProductId = pro.ProductId;
            products.CategoryId = pro.CategoryId;
            products.ProductName = pro.ProductName;
            products.Price = pro.Price;
            products.Stock = pro.Stock;
            products.DateCreate = products.DateCreate; //ngay tao ko sua dc nhung neu ko de vao thi loi nen cho no bang chinh no
            products.Description = pro.Description;    //co the loi do dateCreate duoc ghi vao cot description => can't convert type
            products.ImageSource = pro.ImageSource;
            products.PromotionId = pro.PromotionId;

            res = _rep.UpdateProduct(products);
            return res;
        }

        #endregion

        public object GetAllProductByGender_Linq(bool gender)
        {
            return _rep.GetAllProductByGender_Linq(gender);
        }
        //Product-Sale
        public object GetSP_ProductSale()
        {
            return _rep.GetSP_ProductSale();
        }

        //Product-Accessories
        public object GetSP_ProductAccessories()
        {
            return _rep.GetSP_ProductAccessories();
        }

        public object GetProductByCategoryId_Linq(int categoryId)
        {
            return _rep.GetProductByCategoryId_Linq(categoryId);
        }

        public object GetProductByPromotion_Linq(bool gender)
        {
            return _rep.GetProductByPromotion_Linq(gender);
        }

        //search product accessories
        public object SearchCategory(String keyword, int page, int size)
        {
            return _rep.SearchCategory(keyword, page, size);
        }

        public int DeleteProduct(int id)
        {
            return _rep.DeleteProduct(id);
        }

        //
        
    }
}
