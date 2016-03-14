using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Data
{
	public class QuackEntityContext : DbContext
	{
		public QuackEntityContext()
			:base("Quacker")
		{

		}

		public DbSet<QuackEntity> Quacks { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var config = modelBuilder.Entity<QuackEntity>();

			config.HasKey(x => x.Id)
				.ToTable("Quacks");

			config.Property(x => x.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
				.HasColumnName("QuackId");

			config.Property(x => x.ParentId)
				.HasColumnName("ParentQuackId");

			config.Property(x => x.Content)
				.IsRequired()
				.HasMaxLength(500);

			config.Property(x => x.AuthorName)
				.IsRequired()
				.HasMaxLength(50);

			//config.Property(x => x.CreationDate)
			//	.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

			config.HasOptional(x => x.Parent)
				.WithMany(x => x.Replies)
				.HasForeignKey(x => x.ParentId)
				.WillCascadeOnDelete(false);
		}
	}
}
