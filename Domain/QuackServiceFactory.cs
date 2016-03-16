using Data.Repositories;

namespace Domain
{
	/// <summary>
	/// Factory of quack services
	/// </summary>
	public class QuackServiceFactory
	{
		/// <summary>
		/// Creates an instance of quack service
		/// </summary>
		/// <returns></returns>
		public static IQuackService Create()
		{
			return new QuackService(new QuackEntityRepository());
		}
	}
}
