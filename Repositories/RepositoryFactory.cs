namespace Repositories
{
	public class RepositoryFactory
	{
		public static IGenericRepository<TEntity> Create<TEntity>() where TEntity : class
		{
			return new GenericRepository<TEntity>(); // no more repositories at this point
		}
	}
}
