using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
	public interface IEntityRepository<TEntity> where TEntity : IEntity
	{
		TEntity Add(TEntity entity);
		IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where = null);
		TEntity GetById(int entityId);
	}
}
