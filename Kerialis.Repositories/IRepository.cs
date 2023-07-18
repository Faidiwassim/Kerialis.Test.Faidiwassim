using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Repositories
{
    public interface IRepository<TEntity, TKey, TContext> where TEntity : class where TContext : DbContext
    {
        bool Create(TEntity model);
        Task<bool> CreateAsync(TEntity model);
        bool CreateRange(IEnumerable<TEntity> models);
        Task<bool> CreateRangeAsync(IEnumerable<TEntity> models);
        bool Update(TEntity model);
        Task<bool> UpdateAsync(TEntity model);
        bool UpdateRange(IEnumerable<TEntity> models);
        Task<bool> UpdateRangeAsync(IEnumerable<TEntity> models);
        TEntity Find(TKey key);
        Task<TEntity> FindAsync(TKey key);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate);
        TEntity FindOne(Func<TEntity, bool> predicate);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate);
        bool Delete(TEntity model);
        Task<bool> DeleteAsync(TEntity model);
        bool DeleteRange(IEnumerable<TEntity> models);
        Task<bool> DeleteRangeAsync(IEnumerable<TEntity> models);
        IQueryable<TEntity> FindAsQuerable();
        Task<IQueryable<TEntity>> FindAsQuerableAsync();
        IQueryable<TEntity> FindAsQuerable(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> FindAsQuerableAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
