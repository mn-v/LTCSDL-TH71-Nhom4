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
    using Common.Rsp;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public CategoriesController()
        {
            _svc = new CategoriesSvc();
        }        

        [HttpPost("get-by-id")]
        public IActionResult getCategoryById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res); //phuong thuc tot(200): da dat dc
        }

        [HttpPost("get-all")]
        public IActionResult getAllCategory()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res); //phuong thuc tot(200): da dat dc
        }

        [HttpPost("create-category")]
        public IActionResult CreateCategory([FromBody] CategoriesReq req)
        {
            var res = _svc.CreateCategory(req);

            return Ok(res);
        }

        [HttpPost("update-category")]
        public IActionResult UpdateCategory([FromBody] CategoriesReq req)
        {
            var res = _svc.UpdateCategory(req);

            return Ok(res);
        }

        [HttpPost("delete-category")]
        public IActionResult DeleteCategory(int id)
        {
            var res = _svc.DeleteCategory(id);

            return Ok(res);
        }

        [HttpPost("search-category")]
        public IActionResult SearchCategory([FromBody] SearchReq req)
        {
            var res = new SingleRsp();
            var pro = _svc.SearchCategory(req.Keyword, req.Page, req.Size);
            res.Data = pro;
            return Ok(res);
        }

        private readonly CategoriesSvc _svc;
    }
}