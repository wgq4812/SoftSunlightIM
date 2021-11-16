using SoftSunlightIM.WebApi.IDao;
using SoftSunlightIM.WebApi.IService;
using SoftSunlightIM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftSunlightIM.WebApi.Service
{
    public class UserService : BaseService<User>, IBaseService<User>
    {

        private IUserDao userDao;

        public UserService(IUserDao userDao) : base(userDao)
        {
            this.userDao = userDao;
        }

        public string Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
