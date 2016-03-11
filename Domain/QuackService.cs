using Data;
using Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
	public class QuackService : IQuackService
	{
		private IEntityRepository<QuackEntity> _repository;

		public QuackService(IEntityRepository<QuackEntity> repository)
		{
			_repository = repository;
		}

		public void Add(Quack quack)
		{
			if (quack != null && IsValid(quack))
			{
				var entity = new QuackEntity
				{
					AuthorName = quack.AuthorName,
					Content = quack.Content
				};
				_repository.Add(entity);

				quack.QuackId = entity.Id;
				quack.CreationDate = entity.CreationDate;
			}
		}

		public IEnumerable<Quack> GetAll()
		{
			return _repository.Get(x => !x.ParentId.HasValue).Select(q => FromQuackEntity(q));
		}

		public IEnumerable<Quack> GetReplies(int quackId)
		{
			return _repository.Get(x => x.ParentId == quackId).Select(q => FromQuackEntity(q));
		}

		private bool IsValid(Quack quack)
		{
			return !string.IsNullOrEmpty(quack.Content) && !string.IsNullOrWhiteSpace(quack.Content) && quack.Content.Length <= 500
				&& !string.IsNullOrEmpty(quack.AuthorName) && !string.IsNullOrWhiteSpace(quack.AuthorName) && quack.Content.Length <= 50;
		}

		private Quack FromQuackEntity(QuackEntity entity)
		{
			return new Quack
			{
				QuackId = entity.Id,
				CreationDate = entity.CreationDate,
				Content = entity.Content,
				AuthorName = entity.AuthorName
			};
		}
	}
}
