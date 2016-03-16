using System.Collections.Generic;

namespace Domain
{
	/// <summary>
	/// An interface for a service providing operations on quacks
	/// </summary>
	public interface IQuackService
	{
		/// <summary>
		/// Returns all quacks that are not replies to other quacks
		/// </summary>
		/// <returns></returns>
		IEnumerable<Quack> GetAll();

		/// <summary>
		/// Returns replies for given quack identifier
		/// </summary>
		/// <param name="quackId">Quack's identitfier</param>
		/// <returns></returns>
		IEnumerable<Quack> GetReplies(int quackId);

		/// <summary>
		/// Adds quack
		/// </summary>
		/// <param name="quack">Quack instance to be added</param>
		/// <returns></returns>
		Quack Add(Quack quack);
	}
}
