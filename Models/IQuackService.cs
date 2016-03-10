using System.Collections.Generic;

namespace Models
{
	public interface IQuackService
	{
		void Add(IQuack quack);

		IEnumerable<IQuack> GetAll();
	}
}