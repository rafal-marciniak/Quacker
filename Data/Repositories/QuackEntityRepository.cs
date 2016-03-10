using System;

namespace Data.Repositories
{
	public class QuackEntityRepository : GenericEntityRepository<QuackEntityContext, QuackEntity>
	{
		public QuackEntityRepository()
			: base()
		{
			_context.Configuration.LazyLoadingEnabled = false;
		}

		public override void Add(QuackEntity entity)
		{
			entity.CreationDate = DateTime.Now; // todo: replace it with default value getdate() by EF's migrations

			base.Add(entity);
		}
	}
}
