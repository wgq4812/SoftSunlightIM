using SoftSunlightIM.WebApi.IDao;
using SoftSunlightIM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSunlightIM.WebApi.Dao
{
    public class BaseDao<T> : IBaseDao<T> where T : class
    {
        private IMDbContext dbContext;

        public BaseDao(IMDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Add(IEnumerable<T> entities)
        {
            dbContext.AddRange(entities);
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            dbContext.RemoveRange(entities);
            dbContext.SaveChanges();
        }

        public System.Linq.IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression);
        }

        public System.Linq.IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression, out PageModel pageModel)
        {
            pageModel = new PageModel();
            pageModel.TotalCount = dbContext.Set<T>().Count();
            pageModel.TotalPages = Convert.ToInt32(Math.Ceiling(pageModel.TotalCount * 1.0 / pageModel.PageSize));
            return dbContext.Set<T>().Where(expression).Skip((pageModel.PageNo - 1) * pageModel.PageSize).Take(pageModel.PageSize);
        }

        public void Update(T entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }

        public void Update(IEnumerable<T> entities)
        {
            dbContext.Update(entities);
            dbContext.SaveChanges();
        }
    }
}
