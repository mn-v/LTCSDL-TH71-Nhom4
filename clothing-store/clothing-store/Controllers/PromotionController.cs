using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clothing_store.Promotion
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
    //    public PromotionController()
    //    {
    //        _svc = new PromotionSvc();
    //    }

    //    [HttpPost("get-by-id")]
    //    public IActionResult getPromotionId([FromBody] SimpleReq rep)
    //    {
    //        var res = new SingleRsp();
    //        res = _svc.Read(rep.Id);
    //        return Ok(res);
    //    }

    //    [HttpPost("get-by-all")]
    //    public IActionResult getAllPromotion([FromBody] SimpleReq rep)
    //    {
    //        var res = new SingleRsp();
    //        res.Data = _svc.All;
    //        return Ok(res);
    //    }

    //    [HttpPost("create-promotion")]
    //    public IActionResult CreatePromotion([FromBody] PromotionReq req)
    //    {
    //        var res = _svc.CreatePromotion(req);

    //        return Ok(res);
    //    }

    //    //sửa
    //    [HttpPost("update-promotion")]
    //    public IActionResult UpdatePromotion([FromBody] PromotionReq req)
    //    {
    //        var res = _svc.UpdatePromotion(req);

    //        return Ok(res);
    //    }

    //    [HttpPost("delete-promotion")]
    //    public IActionResult DeletePromotion(int id)
    //    {
    //        var res = _svc.DeletePromotion(id);

    //        return Ok(res);
    //    }

    //    private readonly PromotionSvc _svc;
    }
}