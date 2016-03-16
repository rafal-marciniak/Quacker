using Data;
using Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
	/// <summary>
	/// A service providing operations on quacks
	/// </summary>
	public class QuackService : IQuackService
	{
		#region Private members

		/// <summary>
		/// Quack entities repository
		/// </summary>
		private IEntityRepository<QuackEntity> _repository;

		#endregion

		#region Constructors

		/// <summary>
		/// A service providing operations on quacks
		/// </summary>
		/// <param name="repository"></param>
		public QuackService(IEntityRepository<QuackEntity> repository)
		{
			_repository = repository;
		}

		#endregion

		#region IQuackService implementation

		/// <summary>
		/// Adds quack
		/// </summary>
		/// <param name="quack">Quack instance to be added</param>
		/// <returns></returns>
		public Quack Add(Quack quack)
		{
			if (quack != null && IsValid(quack))
			{
				var result = _repository.Add(ToQuackEntity(quack));
				return FromQuackEntity(result);
			}

			return quack;
		}

		/// <summary>
		/// Returns all quacks that are not replies to other quacks
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Returns replies for given quack identifier
		/// </summary>
		/// <param name="quackId">Quack's identitfier</param>
		/// <returns></returns>
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

		#endregion

		#region Privat members

		private bool IsValid(Quack quack)
		{
			return !string.IsNullOrEmpty(quack.Content) && !string.IsNullOrWhiteSpace(quack.Content) && quack.Content.Length <= 500
				&& !string.IsNullOrEmpty(quack.AuthorName) && !string.IsNullOrWhiteSpace(quack.AuthorName) && quack.AuthorName.Length <= 50;
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

		#endregion
	}
}
