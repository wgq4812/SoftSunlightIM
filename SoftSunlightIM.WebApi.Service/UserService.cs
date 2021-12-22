using SoftSunlightIM.WebApi.IDao;
using SoftSunlightIM.WebApi.IService;
using SoftSunlightIM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoftSunlightIM.WebApi.Service
{
    public class UserService : BaseService<User>, IUserService
    {

        private IUserDao userDao;

        public UserService(IUserDao userDao) : base(userDao)
        {
            this.userDao = userDao;
        }

        public string Login(User user)
        {
            try
            {
                var result = userDao.Get(p => p.Account.Equals(user.Account) && p.Password.Equals(user.Password)).FirstOrDefault();
                if (result == null)
                {
                    return "用户名或密码错误";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

        public string Register(User user)
        {
            try
            {
                var result = userDao.Get(p => p.Account.Equals(user.Account)).FirstOrDefault();
                if (result != null)
                {
                    return "该账号已注册";
                }
                user.CreateTime = DateTime.Now;
                userDao.Add(user);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }
    }
}
