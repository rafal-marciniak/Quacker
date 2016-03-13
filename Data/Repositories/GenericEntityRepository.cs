using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
	public abstract class GenericEntityRepository<TContext, TEntity> : IEntityRepository<TEntity>, IDisposable
		where TContext : DbContext, new()
		where TEntity : class, IEntity
	{
		protected TContext _context;

		protected GenericEntityRepository()
		{
			_context = new TContext();
		}

		#region IRepository<TEntity> implementation

		public virtual TEntity Add(TEntity entity)
		{
			var result = TakeSet().Add(entity);
			SaveChanges();

			return result;
		}

		public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
		{
			IQueryable<TEntity> query = TakeSet();

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			return query;
		}

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
