using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Repositories
{
	public interface IEntityRepository<TEntity> where TEntity : IEntity
	{
		void Add(TEntity entity);
		//void Edit(TEntity entity);
		//void Remove(TEntity entity);

		IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null);
		TEntity GetById(int entityId);
	}
}
