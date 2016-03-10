using Models.Repositories;
using System.Collections.Generic;

namespace Models
{
	public class QuackService : IQuackService
	{
		public IEnumerable<IQuack> GetAll()
		{
			var repo = new QuackRepository();
			return repo.Get();
		}

		public void Add(IQuack quack)
		{
			//TODO: validation

			var repo = new QuackRepository();
			repo.Add(quack);
		}
	}
}
