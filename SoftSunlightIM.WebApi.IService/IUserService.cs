using SoftSunlightIM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftSunlightIM.WebApi.IService
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    /// <typeparam name="User"></typeparam>
    public interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string Register(User user);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string Login(User user);
    }
}
