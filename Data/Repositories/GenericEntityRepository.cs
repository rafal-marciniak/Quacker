using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
	/// <summary>
	/// Generic implementation of entity repository
	/// </summary>
	/// <typeparam name="TContext">Type of database context</typeparam>
	/// <typeparam name="TEntity">Type of entity</typeparam>
	public abstract class GenericEntityRepository<TContext, TEntity> : IEntityRepository<TEntity>, IDisposable
		where TContext : DbContext, new()
		where TEntity : class, IEntity
	{
		#region Protected memners

		/// <summary>
		/// Database context
		/// </summary>
		protected TContext _context;

		#endregion

		#region Constructors

		/// <summary>
		/// Generic implementation of entity repository
		/// </summary>
		protected GenericEntityRepository()
		{
			_context = new TContext();
		}

		#endregion

		#region IRepository<TEntity> implementation

		/// <summary>
		/// Adds entity
		/// </summary>
		/// <param name="entity">Entity to be added</param>
		/// <returns></returns>
		public virtual TEntity Add(TEntity entity)
		{
			var result = TakeSet().Add(entity);
			SaveChanges();

			return result;
		}

		/// <summary>
		/// Gets a collection of entities
		/// </summary>
		/// <param name="predicate">Predicate expression to filter data</param>
		/// <returns></returns>
		public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
		{
			IQueryable<TEntity> query = TakeSet();

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			return query;
		}

		/// <summary>
		/// Gets an entity by id
		/// </summary>
		/// <param name="entityId">Entity's identifier</param>
		/// <returns></returns>
		public virtual TEntity GetById(int entityId)
		{
			return TakeSet().Find(entityId);
		}

		#endregion

		#region IDisposable implementation

		private bool _disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}

			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		#region Protected methods

		protected DbSet<TEntity> TakeSet()
		{
			return _context.Set<TEntity>();
		}

		protected void SaveChanges()
		{
			_context.SaveChanges();
		}

		#endregion
	}
}
