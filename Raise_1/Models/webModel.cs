namespace Raise_1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class webModel : DbContext
    {
        public webModel()
            : base("name=webModel")
        {
        }

        public virtual DbSet<Summary> Summary { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Summary)
                .WithRequired(e => e.Topic)
                .WillCascadeOnDelete(false);
        }
    }
}
