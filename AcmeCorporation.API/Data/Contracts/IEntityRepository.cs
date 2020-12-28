using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcmeCorporation.API.Data.Contracts
{
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        IQueryable<TEntity> GetAll();
        Task<TEntity> Add(TEntity entity);
        // void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        Task<IEnumerable<TEntity>> AddRange(IList<TEntity> entity);
        void SaveChanges();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    }
}