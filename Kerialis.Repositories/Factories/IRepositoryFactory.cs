using Microsoft.EntityFrameworkCore;

namespace Kerialis.Repositories.Factories
{
	public interface IRepositoryFactory<TContext> where TContext : DbContext
	{
		IRepository<TEntity, TKey, TContext> Create<TEntity, TKey>()
		where TEntity : class
		where TKey : IEquatable<TKey>;
	}
}