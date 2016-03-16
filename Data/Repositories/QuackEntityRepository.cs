using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
	/// <summary>
	/// Quack entities repository
	/// </summary>
	public class QuackEntityRepository : GenericEntityRepository<QuackerContext, QuackEntity>
	{
		#region Constructors

		/// <summary>
		/// Quack entities repository
		/// </summary>
		public QuackEntityRepository()
			: base()
		{
			_context.Configuration.LazyLoadingEnabled = false;
		}

		#endregion

		#region Override

		/// <summary>
		/// Adds entity
		/// </summary>
		/// <param name="entity">Entity to be added</param>
		/// <returns></returns>
		public override QuackEntity Add(QuackEntity entity)
		{
			entity.CreationDate = DateTime.Now; // todo: replace it wih column default value (getdate()) using EF's migrations
			return base.Add(entity);
		}

		/// <summary>
		/// Gets a collection of entities
		/// </summary>
		/// <param name="predicate">Predicate expression to filter data</param>
		/// <returns></returns>
		public override IQueryable<QuackEntity> Get(Expression<Func<QuackEntity, bool>> predicate = null)
		{
			var query = base.Get(predicate);
			query = query.Include("Replies");

			return query;
		}

		#endregion
	}
}
