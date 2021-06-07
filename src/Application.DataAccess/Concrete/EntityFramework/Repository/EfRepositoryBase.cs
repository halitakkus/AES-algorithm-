using Application.Core.Entities.Concrete;
using Application.DataAccess.Abstract.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Core.Configuration.Context;
using Application.DataAccess.Concrete.EntityFramework.Context;

namespace Application.DataAccess.Concrete.EntityFramework.Repository
{
    /// <summary>
    /// Generic repository base.
    /// </summary>
    /// <typeparam name="TEntity">TEntity is database entity.</typeparam>
    /// <typeparam name="TKey">Unique key of TEntity.</typeparam>
    public class EfRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        private readonly string _connectionString;

        public EfRepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Add(TEntity entity)
        {
            using (var context = new Context.ApplicationDbContext(_connectionString))
            {
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;

                context.Attach<TEntity>(entity).State = EntityState.Added;
                return context.SaveChanges() > 0;
            }
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            using (var context = new Context.ApplicationDbContext(_connectionString))
            {
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;

                context.Attach<TEntity>(entity).State = EntityState.Added;

                return await context.SaveChangesAsync() > 0;
            }
        }

        public TEntity GetById(TKey id)
        {
            using (var context = new Context.ApplicationDbContext(_connectionString))
            {
                return Queryable.FirstOrDefault<TEntity>(context.Set<TEntity>(), (Expression<Func<TEntity, bool>>)(entity => (bool)entity.Id.Equals((object)id)));
            }
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            using (var context = new Context.ApplicationDbContext(_connectionString))
            {
                return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync<TEntity>(context.Set<TEntity>(), (Expression<Func<TEntity, bool>>)(entity => (bool)entity.Id.Equals((object)id)));
            }
        }

        public int GetCount()
        {
            using (Context.ApplicationDbContext context = new Context.ApplicationDbContext(_connectionString))
            {
                return Queryable.Count<TEntity>(context.Set<TEntity>());
            }
        }

        public async Task<int> GetCountAsync()
        {
            using (Context.ApplicationDbContext context = new Context.ApplicationDbContext(_connectionString))
            {
                return await EntityFrameworkQueryableExtensions.CountAsync<TEntity>(context.Set<TEntity>());
            }
        }

        public List<TEntity> GetList()
        {
            using (var context = new Context.ApplicationDbContext(_connectionString))
            {
                return Enumerable.ToList<TEntity>(context.Set<TEntity>());
            }
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            using (var context = new Context.ApplicationDbContext(_connectionString))
            {
                return await EntityFrameworkQueryableExtensions.ToListAsync<TEntity>(context.Set<TEntity>());
            }
        }

        public bool Remove(TEntity entity)
        {
            using (var context = new Context.ApplicationDbContext(_connectionString))
            {
                context.Attach<TEntity>(entity).State = EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
            using (var context = new Context.ApplicationDbContext(_connectionString))
            {
                context.Attach<TEntity>(entity).State = EntityState.Deleted;
                return await context.SaveChangesAsync() > 0;
            }
        }

        public bool Update(TEntity entity)
        {
            using (var context = new Context.ApplicationDbContext(_connectionString))
            {
                entity.ModifiedDate = DateTime.Now;

                context.Attach<TEntity>(entity).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            using (var context = new Context.ApplicationDbContext(_connectionString))
            {
                entity.ModifiedDate = DateTime.Now;

                context.Attach<TEntity>(entity).State = EntityState.Modified;

                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}
