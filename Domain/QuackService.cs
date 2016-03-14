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

		public Quack Add(Quack quack)
		{
			if (quack != null && IsValid(quack))
			{
				var result = _repository.Add(ToQuackEntity(quack));
				return FromQuackEntity(result);
			}

			return quack;
		}

		public IEnumerable<Quack> GetAll()
		{
			return _repository.Get(x => !x.ParentId.HasValue).Select(q => new Quack
			{
				QuackId = q.Id,
				CreationDate = q.CreationDate,
				Content = q.Content,
				AuthorName = q.AuthorName,
				ParentQuackId = q.ParentId,
				RepliesCount = q.Replies.Count
			});
		}

		public IEnumerable<Quack> GetReplies(int quackId)
		{
			return _repository.Get(x => x.ParentId == quackId).Select(q => new Quack
			{
				QuackId = q.Id,
				CreationDate = q.CreationDate,
				Content = q.Content,
				AuthorName = q.AuthorName,
				ParentQuackId = q.ParentId,
				RepliesCount = q.Replies.Count
			});
		}

		private bool IsValid(Quack quack)
		{
			return !string.IsNullOrEmpty(quack.Content) && !string.IsNullOrWhiteSpace(quack.Content) && quack.Content.Length <= 250
				&& !string.IsNullOrEmpty(quack.AuthorName) && !string.IsNullOrWhiteSpace(quack.AuthorName) && quack.AuthorName.Length <= 25;
		}

		private QuackEntity ToQuackEntity(Quack quack)
		{
			return new QuackEntity
			{
				Id = quack.QuackId,
				CreationDate = quack.CreationDate,
				Content = quack.Content,
				AuthorName = quack.AuthorName,
				ParentId = quack.ParentQuackId
			};
		}

		private Quack FromQuackEntity(QuackEntity quackEntity)
		{
			return new Quack
			{
				QuackId = quackEntity.Id,
				CreationDate = quackEntity.CreationDate,
				Content = quackEntity.Content,
				AuthorName = quackEntity.AuthorName,
				ParentQuackId = quackEntity.ParentId,
				RepliesCount = quackEntity.Replies != null ? quackEntity.Replies.Count : 0
			};
		}
	}
}
