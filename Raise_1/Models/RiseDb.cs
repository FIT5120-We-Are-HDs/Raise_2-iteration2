namespace Raise_1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Infrastructure;

    public partial class RiseDb : DbContext
    {
        public RiseDb()
            : base("name=rise-db")
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
            /*throw new UnintentionalCodeFirstException();*/

        }
    }
}
