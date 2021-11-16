using SoftSunlightIM.WebApi.IDao;
using SoftSunlightIM.WebApi.IService;
using SoftSunlightIM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SoftSunlightIM.WebApi.Service
{
    /// <summary>
    /// 服务层基础类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : IBaseService<T>
    {
        private IBaseDao<T> baseDao;
        public BaseService(IBaseDao<T> baseDao)
        {
            this.baseDao = baseDao;
        }

        public void Add(T entity)
        {
            baseDao.Add(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            baseDao.Add(entities);
        }

        public void Delete(T entity)
        {
            baseDao.Delete(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            baseDao.Delete(entities);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return baseDao.Get(expression);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression, out PageModel pageModel)
        {
            return baseDao.Get(expression, out pageModel);
        }

        public void Update(T entity)
        {
            baseDao.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            baseDao.Update(entities);
        }
    }
}
