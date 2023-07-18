using Microsoft.EntityFrameworkCore;

namespace Kerialis.Repositories.Factories
{
	public class RepositoryFactory<TContext> : IRepositoryFactory<TContext> where TContext :DbContext
	{
		private readonly TContext _context;
		public RepositoryFactory(TContext context)
		{
			_context = context;
		}
		public IRepository<TEntity , TKey , TContext> Create<TEntity , TKey>() 
			where TEntity : class
			where TKey : IEquatable<TKey>
		{
			return new Repository<TEntity, TKey, TContext>(_context);
		}
	}
}
