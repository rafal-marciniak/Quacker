using System;
using System.Collections.Generic;

namespace Data
{
	public class QuackEntity : IEntity
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public string AuthorName { get; set; }

		public DateTime CreationDate { get; set; }

		public int? ParentId { get; set; }

		public QuackEntity Parent { get; set; }

		public virtual ICollection<QuackEntity> Replies { get; set; }
	}
}
 