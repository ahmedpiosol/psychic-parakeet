namespace TestApp
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using TestApp.Model;
    using TestApp.Model.Items;

    public class DataContext : DbContext
    {
        // Your context has been configured to use a 'DataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TestApp.DataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataContext' 
        // connection string in the application configuration file.
        public DataContext()
            : base("name=DataContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*--------------Users Table--------------*/
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();
            /*--------------Items Table--------------*/
            modelBuilder.Entity<Item>()
                .Property(i => i.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Item>()
                .Property(i => i.NameAr)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Item>()
                .Property(i => i.NameEn)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Item>()
                .Property(i => i.NameEn)
                .IsOptional();
            modelBuilder.Entity<Item>()
                .Property(i => i.Image)
                .HasColumnType("image")
                .IsOptional();
            modelBuilder.Entity<Item>()
                .Property(m => m.EditDate)
                .IsOptional();
            modelBuilder.Entity<Item>()
                .HasRequired(u => u.Units)
                .WithMany(i => i.Items)
                .HasForeignKey(u => u.UnitId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Item>()
                .HasRequired(u => u.Creators)
                .WithMany()
                .HasForeignKey(u => u.CreatedById)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Item>()
                .HasOptional(u => u.Editors)
                .WithMany()
                .HasForeignKey(u => u.EditedById)
                .WillCascadeOnDelete(false);
            /*--------------Units Table--------------*/
            modelBuilder.Entity<Unit>()
                .Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Unit>()
               .Property(u => u.Name)
               .IsRequired()
               .HasMaxLength(50);
            modelBuilder.Entity<Unit>()
                .HasRequired(u => u.Creators)
                .WithMany()
                .HasForeignKey(u => u.CreatedById)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Unit>()
                .HasOptional(u => u.Editors)
                .WithMany()
                .HasForeignKey(u => u.EditedById)
                .WillCascadeOnDelete(false);

            /*------------------------------*/
            base.OnModelCreating(modelBuilder);
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Unit> Units { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}