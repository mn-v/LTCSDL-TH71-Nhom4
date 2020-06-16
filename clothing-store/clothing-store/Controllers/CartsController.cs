using Microsoft.AspNetCore.Mvc;

namespace clothing_store.Controllers
{
    using BLL;
    using Common.Req;
    using Common.Rsp;

    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        public CartsController()
        {
            _svc = new CartsSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getCartId([FromBody] SimpleReq rep)
        {
            var res = new SingleRsp();
            res = _svc.Read(rep.Id);
            return Ok(res);
        }

        [HttpPost("get-by-all")]
        public IActionResult getAllCarts([FromBody] SimpleReq rep)
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        // Create new
        [HttpPost("create-cart")]
        public IActionResult CreateCart([FromBody] CartsReq req)
        {
            var res = _svc.CreateCart(req);

            return Ok(res);
        }

        // Edit
        [HttpPost("update-cart")]
        public IActionResult UpdateCart(int CartId, string Size, short Quantity)
        {
            var res = _svc.UpdateCart(CartId, Size, Quantity);

            return Ok(res);
        }

        // Delete
        [HttpPost("delete-cart")]
        public IActionResult DeleteCart([FromBody] CartsReq req)
        {
            var res = _svc.DeleteCart(req.CartId);

            return Ok(res);
        }

        private readonly CartsSvc _svc;
    }
}