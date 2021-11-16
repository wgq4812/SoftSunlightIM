using SoftSunlightIM.WebApi.IDao;
using SoftSunlightIM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftSunlightIM.WebApi.Dao
{
    public class UserDao : BaseDao<User>, IUserDao
    {
        private IMDbContext dbContext;

        public UserDao(IMDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }



    }
}
