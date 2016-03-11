using System.Collections.Generic;

namespace Domain
{
	public interface IQuackService
	{
		IEnumerable<Quack> GetAll();
		IEnumerable<Quack> GetReplies(int quackId);
		void Add(Quack quack);
	}
}
