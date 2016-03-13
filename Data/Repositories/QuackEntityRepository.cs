using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
	public class QuackEntityRepository : GenericEntityRepository<QuackEntityContext, QuackEntity>
	{
		public QuackEntityRepository()
			: base()
		{
			_context.Configuration.LazyLoadingEnabled = false;
		}

		public override IQueryable<QuackEntity> Get(Expression<Func<QuackEntity, bool>> predicate = null)
		{
			var query = base.Get(predicate);
			query = query.Include("Replies");

			return query;
		}

		public override QuackEntity Add(QuackEntity entity)
		{
			entity.CreationDate = DateTime.Now; // todo: replace it wih column default value (getdate()) using EF's migrations
			return base.Add(entity);
		}
	}
}
