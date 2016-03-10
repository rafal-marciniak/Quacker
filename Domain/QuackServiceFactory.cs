using Data.Repositories;

namespace Domain
{
	public class QuackServiceFactory
	{
		public static IQuackService Create()
		{
			return new QuackService(new QuackEntityRepository());
		}
	}
}
