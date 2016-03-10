using System.Collections.Generic;

namespace Domain
{
	public interface IQuackService
	{
		IEnumerable<Quack> GetAll();
		IEnumerable<Quack> GetReplies(Quack quack);
		void Add(Quack quack);
	}
}
