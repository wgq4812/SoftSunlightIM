using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftSunlightIM.WebApi.IService;
using SoftSunlightIM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftSunlightIM.WebApi.Controllers
{
    /// <summary>
    /// 用户管理控制器
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IActionResult Register(User user)
        {
            string errMsg = userService.Register(user);
            return new JsonResult(new
            {
                Success = string.IsNullOrEmpty(errMsg),
                ErrorMsg = errMsg
            });
        }

    }
}
