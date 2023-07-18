using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Repositories
{
    public class Repository<TEntity, TKey, TContext> : IRepository<TEntity, TKey, TContext> where TEntity : class where TContext : DbContext
    {
        private readonly TContext _context;
        public Repository(TContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Insert e new instance for TEntity in the database
        /// </summary>
        /// <param name="model" type="TEntity">TEntity class</param>
        /// <returns type="bool">True if success else false</returns>
        public virtual bool Create(TEntity model)
        {
            try
            {
                _context.Set<TEntity>().Add(model);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<bool> CreateAsync(TEntity model)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public virtual bool CreateRange(IEnumerable<TEntity> models)
        {
            try
            {
                _context.Set<TEntity>().AddRange(models);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<bool> CreateRangeAsync(IEnumerable<TEntity> models)
        {
            try
            {
                await _context.Set<TEntity>().AddRangeAsync(models);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public virtual bool Delete(TEntity model)
        {
            try
            {
                _context.Set<TEntity>().Remove(model);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<bool> DeleteAsync(TEntity model)
        {
            try
            {
                _context.Set<TEntity>().Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public virtual bool DeleteRange(IEnumerable<TEntity> models)
        {
            try
            {
                _context.Set<TEntity>().RemoveRange(models);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<bool> DeleteRangeAsync(IEnumerable<TEntity> models)
        {
            try
            {
                _context.Set<TEntity>().RemoveRange(models);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        public virtual TEntity Find(TKey key)
        {
            try
            {
                return _context.Set<TEntity>().Find(key);

            }
            catch
            {
                throw;
            }
        }

        public virtual IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            try
            {
                return _context.Set<TEntity>().Where(predicate);

            }
            catch
            {
                throw;
            }
        }



        public virtual IQueryable<TEntity> FindAsQuerable()
        {
            try
            {
                return _context.Set<TEntity>();

            }
            catch
            {
                throw;
            }
        }

        public virtual IQueryable<TEntity> FindAsQuerable(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _context.Set<TEntity>().Where(predicate);

            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<IQueryable<TEntity>> FindAsQuerableAsync()
        {
            try
            {
                return _context.Set<TEntity>();

            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<IQueryable<TEntity>> FindAsQuerableAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _context.Set<TEntity>().Where(predicate).AsQueryable();

            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TEntity> FindAsync(TKey key)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(key);

            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return _context.Set<TEntity>().Where(predicate);

            }
            catch
            {
                throw;
            }
        }

        public virtual TEntity FindOne(Func<TEntity, bool> predicate)
        {
            try
            {
                return _context.Set<TEntity>().FirstOrDefault(predicate);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);

            }
            catch
            {
                throw;
            }
        }

        public virtual bool Update(TEntity model)
        {
            try
            {

                _context.Set<TEntity>().Update(model);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<bool> UpdateAsync(TEntity model)
        {
            try
            {
                _context.Set<TEntity>().Update(model);
                await _context.SaveChangesAsync();
                return true;

            }
            catch
            {
                throw;
            }
        }

        public virtual bool UpdateRange(IEnumerable<TEntity> models)
        {
            try
            {
                _context.Set<TEntity>().UpdateRange(models);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public virtual async Task<bool> UpdateRangeAsync(IEnumerable<TEntity> models)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Set<TEntity>().UpdateRange(models);
                await _context.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
