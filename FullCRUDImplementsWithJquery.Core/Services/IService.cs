using FullCRUDImplementationWithJquery.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        BaseResponse<TEntity> GetById(int id);

        BaseResponse<IEnumerable<TEntity>> GetAll();

        BaseResponse<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        BaseResponse<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        BaseResponse<TEntity> Add(TEntity entity);

        BaseResponse<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities);

        BaseResponse<TEntity> Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        BaseResponse<TEntity> Update(TEntity entity);
    }
}
