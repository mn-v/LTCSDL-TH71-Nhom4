using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clothing_store.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using System.Collections;
    using Common.Rsp;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
            _svc = new ProductsSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getProductsId([FromBody] SimpleReq rep)
        {
            var res = new SingleRsp();
            res = _svc.Read(rep.Id);
            return Ok(res);
        }

        [HttpPost("get-by-all")]
        public IActionResult getAllProducts([FromBody] SimpleReq rep)
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        // đưa ra swagger
        [HttpPost("search-product")]
        public IActionResult SearchProduct([FromBody] SearchReq req)
        {
            var res = new SingleRsp();
            var pro = _svc.SearchProduct(req.Keyword, req.Page, req.Size);
            res.Data = pro;
            return Ok(res);
        }

        //thêm
        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] ProductsReq req)
        {
            var res = _svc.CreateProduct(req);

            return Ok(res);
        }

        //sửa
        [HttpPost("update-product")]
        public IActionResult UpdateProduct([FromBody] ProductsReq req)
        {
            var res = _svc.UpdateProduct(req);

            return Ok(res);
        }

        [HttpPost("delete-product")]
        public IActionResult DeleteProduct(int id)
        {
            var res = _svc.DeleteProduct(id);

            return Ok(res);
        }

        [HttpPost("get-all-product-by-gender-linq")]
        public IActionResult GetAllProductByGender_Linq([FromBody]CategoriesReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.GetAllProductByGender_Linq(req.Gender);
            res.Data = hist;
            return Ok(res);
        }

        [HttpPost("get-product-by-categoryId-linq")]
        public IActionResult GetProductByCategoryId_Linq([FromBody]CategoriesReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.GetProductByCategoryId_Linq(req.CategoryId);
            res.Data = hist;
            return Ok(res);
        }

        [HttpPost("get-product-by-promotion-linq")]
        public IActionResult GetProductByPromotion_Linq([FromBody]CategoriesReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.GetProductByPromotion_Linq(req.Gender);
            res.Data = hist;
            return Ok(res);
        }

        //Product-Sale
        [HttpPost("get-product-sale")]
        public IActionResult GetSP_ProductSale([FromBody]ProductsReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.GetSP_ProductSale();
            res.Data = hist;
            return Ok(res);
        }

        //Product-Accessories
        [HttpPost("get-product-accessories")]
        public IActionResult GetSP_ProductAccessories([FromBody]ProductsReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.GetSP_ProductAccessories();
            res.Data = hist;
            return Ok(res);
        }

        private readonly ProductsSvc _svc;
    }
}