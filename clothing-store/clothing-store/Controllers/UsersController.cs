using Microsoft.AspNetCore.Mvc;

namespace clothing_store.Controllers
{
    using BLL;
    using Common.Req;
    using Common.Rsp;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {
            _svc = new UsersSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getUsersId([FromBody] SimpleReq rep)
        {
            var res = new SingleRsp();
            res = _svc.Read(rep.Id);
            return Ok(res);
        }


        [HttpPost("get-by-all")]
        public IActionResult getAllUsers([FromBody] SimpleReq rep)
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        // đưa ra swagger
        [HttpPost("search-user")]
        public IActionResult SearchUser([FromBody] SearchReq req)
        {
            var res = new SingleRsp();
            var pro = _svc.SearchUser(req.Keyword, req.Page, req.Size);
            res.Data = pro;
            return Ok(res);
        }

        [HttpPost("create-user")]
        public IActionResult CreateProduct([FromBody] UsersReq req)
        {
            var res = _svc.CreateUser(req);

            return Ok(res);
        }

        [HttpPost("check-tai-khoan")]
        public IActionResult CheckAcc_Linq([FromBody]UsersReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.CheckAcc_Linq(req.UserName, req.PassWord);
            return Ok(res);
        }

        private readonly UsersSvc _svc;
    }
}