using System;
using System.Collections.Generic;

namespace Data
{
	/// <summary>
	/// A quack entity
	/// </summary>
	public class QuackEntity : IEntity
	{
		/// <summary>
		/// Quack's identifier
		/// </summary>
		public int Id { get; set; }

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
		public DateTime CreationDate { get; set; }

		/// <summary>
		/// Parent quack's identifier
		/// </summary>
		public int? ParentId { get; set; }

		/// <summary>
		/// Quack's parent
		/// </summary>
		public QuackEntity Parent { get; set; }

		/// <summary>
		/// Collection of quack's relies
		/// </summary>
		public virtual ICollection<QuackEntity> Replies { get; set; }
	}
}
 