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
        public PromotionController()
        {
            _svc = new PromotionSvc();
        }

        private readonly PromotionSvc _svc;
    }
}