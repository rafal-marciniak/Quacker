using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
	/// <summary>
	/// An interface for entity repositories
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public interface IEntityRepository<TEntity> where TEntity : IEntity
	{
		/// <summary>
		/// Adds entity
		/// </summary>
		/// <param name="entity">Entity to be added</param>
		/// <returns></returns>
		TEntity Add(TEntity entity);

		/// <summary>
		/// Gets a collection of entities
		/// </summary>
		/// <param name="predicate">Predicate expression to filter data</param>
		/// <returns></returns>
		IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);

		/// <summary>
		/// Gets an entity by id
		/// </summary>
		/// <param name="entityId">Entity's identifier</param>
		/// <returns></returns>
		TEntity GetById(int entityId);
	}
}
