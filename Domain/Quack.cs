using System;

namespace Domain
{
	/// <summary>
	/// A quack
	/// </summary>
	public class Quack
	{
		/// <summary>
		/// Quack's identifier
		/// </summary>
		public int QuackId { get; internal set; }

		/// <summary>
		/// Quack's content
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// Name of the author
		/// </summary>
		public string AuthorName { get; set; }

		/// <summary>
		/// Quack's creation date
		/// </summary>
		public DateTime CreationDate { get; internal set; }

		/// <summary>
		/// Parent quack's identifier
		/// </summary>
		public int? ParentQuackId { get; set; }

		/// <summary>
		/// Quack's replies count
		/// </summary>
		public int RepliesCount { get; set; }
	}
}
