using SoftSunlightIM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SoftSunlightIM.WebApi.IService
{
    /// <summary>
    /// 服务层基础类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        void Add(IEnumerable<T> entities);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities"></param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> expression);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> expression, out PageModel pageModel);
    }
}
