using FullCRUDImplementationWithJquery.Core.ErrorMessage;
using FullCRUDImplementationWithJquery.Core.Repositories;
using FullCRUDImplementationWithJquery.Core.Responses;
using FullCRUDImplementationWithJquery.Core.Services;
using FullCRUDImplementationWithJquery.Core.UnitOfWorks;
using FullCRUDImplementationWithJquery.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FullCRUDImplementationWithJquery.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly IUnitOfwork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public Service(IUnitOfwork unitOfwork,IRepository<TEntity> repository) {
            this._unitOfWork = unitOfwork;
            this._repository = repository;
        }

        public BaseResponse<TEntity> Add(TEntity entity) {
            try {
                this._repository.Add(entity);
                this._unitOfWork.Commit();
                return new BaseResponse<TEntity>(entity);
            }
            catch (Exception) {
                return new BaseResponse<TEntity>(new ErrorMessageCode().ErrorCreated);
            }
        }

        public BaseResponse<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<IEnumerable<TEntity>> GetAll()
        {
            try {
                IEnumerable<TEntity> entity=this._repository.GetAll();
                return new BaseResponse<IEnumerable<TEntity>>(entity);
            }
            catch (Exception) {
                return new BaseResponse<IEnumerable<TEntity>>(new ErrorMessageCode().ErrorCreated);
            }
        }

        public BaseResponse<TEntity> GetById(int id) {
            try {
                var entity = this._repository.GetById(id);
                if (entity != null) {
                    return new BaseResponse<TEntity>(entity);
                }
                return new BaseResponse<TEntity>(new ErrorMessageCode().NoEntity);
            }
            catch (Exception) {
                return new BaseResponse<TEntity>(new ErrorMessageCode().ErrorCreated);
            }
        }

        public BaseResponse<TEntity> Remove(TEntity entity)
        {
            try {
                this._repository.Remove(entity);
                this._unitOfWork.Commit();
                return new BaseResponse<TEntity>(null);
            }
            catch (Exception) {
                return new BaseResponse<TEntity>(new ErrorMessageCode().ErrorCreated);
                throw;
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            try {
                var entity = this._repository.SingleOrDefault(predicate);
                if (entity != null) {
                    return new BaseResponse<TEntity>(entity);
                }
                return new BaseResponse<TEntity>(new ErrorMessageCode().NoEntity);
            }
            catch (Exception) {
                return new BaseResponse<TEntity>(new ErrorMessageCode().ErrorCreated);
            }
        }

        public BaseResponse<TEntity> Update(TEntity entity)
        {
            try {
                this._repository.Update(entity);
                this._unitOfWork.Commit();
                return new BaseResponse<TEntity>(entity);
            }
            catch (Exception) {
                return new BaseResponse<TEntity>(new ErrorMessageCode().ErrorCreated);
            }
        }

        public BaseResponse<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
