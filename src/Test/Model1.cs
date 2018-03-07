namespace TestApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Barcodes> Barcodes { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany(e => e.Barcodes)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.CreatedById)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Barcodes1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.EditedById);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Item)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.EditedById);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Item1)
                .WithRequired(e => e.Users1)
                .HasForeignKey(e => e.CreatedById)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Units)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.CreatedById)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Units1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.EditedById);
        }
    }
}
