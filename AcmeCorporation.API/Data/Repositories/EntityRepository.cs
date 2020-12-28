using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AcmeCorporation.API.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.API.Data.Repositories
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public DbSet<TEntity> dbSet { get; set; }

        public EntityRepository(DbContext dbContext)
        {
            _context = dbContext;
            dbSet = _context.Set<TEntity>();
        }
        public async virtual Task<TEntity> Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public async virtual Task<IEnumerable<TEntity>> AddRange(IList<TEntity> entity)
        {
            await dbSet.AddRangeAsync(entity);
            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
           dbSet.Remove(entity);
        }

        public async virtual void Delete(int id)
        {
            var entity = await Get(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public async virtual Task<TEntity> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        // public virtual void Update(TEntity entity)
        // {
        //     dbSet.Attach(entity);
        //     _context.Entry(entity).State = EntityState.Modified;
        // }

        public void SaveChanges()
        {
        _context.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }
    }
}