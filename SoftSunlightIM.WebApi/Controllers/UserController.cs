using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftSunlightIM.WebApi.Controllers
{
    /// <summary>
    /// 用户管理控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IActionResult Register()
        {

            return new JsonResult(new
            {

            });
        }
    }
}
