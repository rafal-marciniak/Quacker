using System;
using System.Collections.Generic;

namespace Repositories
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		void Add(TEntity entity);
		void Edit(TEntity entity);
		void Remove(TEntity entity);

		IEnumerable<TEntity> Get(Func<TEntity, bool> where = null);
		TEntity GetById(int entityId);
	}
}
