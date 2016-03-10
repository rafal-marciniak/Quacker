using System;

namespace Domain
{
	public class Quack
	{
		public int QuackId { get; internal set; }

		public string Content { get; set; }

		public string AuthorName { get; set; }

		public DateTime CreationDate { get; internal set; }

		public int? ParentQuackId { get; set; }
	}
}
