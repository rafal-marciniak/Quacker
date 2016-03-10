using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Repositories
{
	internal class GenericRepository<TEntity> : IGenericRepository<TEntity>, IDisposable where TEntity : class
	{
		internal GenericRepository(DbContext context)
		{

		}

		public void Add(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Edit(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TEntity> Get(Func<TEntity, bool> where = null)
		{
			throw new NotImplementedException();
		}

		public TEntity GetById(int entityId)
		{
			throw new NotImplementedException();
		}

		public void Remove(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
