namespace BookEntity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Entity : DbContext
    {
        public Entity()
            : base("name=Entity")
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<BillDetails> BillDetails { get; set; }
        public virtual DbSet<BookCategory> BookCategory { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BooksAuthors> BooksAuthors { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CoustomerDetails> CoustomerDetails { get; set; }
        public virtual DbSet<CoustomerOrder> CoustomerOrder { get; set; }
        public virtual DbSet<CoustomerSubscription> CoustomerSubscription { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PaymentDetails> PaymentDetails { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.House)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Locality)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.pin)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.landmark)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.CoustomerDetails)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Authors>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<Authors>()
                .HasMany(e => e.BooksAuthors)
                .WithRequired(e => e.Authors)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookCategory>()
                .Property(e => e.BookId)
                .IsUnicode(false);

            modelBuilder.Entity<BookCategory>()
                .Property(e => e.BookCategory1)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.BookId)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.BookName)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.Publisher_)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .HasMany(e => e.BookCategory)
                .WithRequired(e => e.Books)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Books>()
                .HasMany(e => e.BooksAuthors)
                .WithRequired(e => e.Books)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Books>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Books)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BooksAuthors>()
                .Property(e => e.BookId)
                .IsUnicode(false);

            modelBuilder.Entity<BooksAuthors>()
                .Property(e => e.BookAuthorid)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.BookCategory)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CoustomerDetails>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<CoustomerDetails>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<CoustomerDetails>()
                .HasMany(e => e.BillDetails)
                .WithRequired(e => e.CoustomerDetails)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CoustomerDetails>()
                .HasMany(e => e.CoustomerOrder)
                .WithRequired(e => e.CoustomerDetails)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CoustomerDetails>()
                .HasMany(e => e.CoustomerSubscription)
                .WithRequired(e => e.CoustomerDetails)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CoustomerDetails>()
                .HasMany(e => e.PaymentDetails)
                .WithRequired(e => e.CoustomerDetails)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CoustomerSubscription>()
                .Property(e => e.CustomerSubscription)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.BookId)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentDetails>()
                .Property(e => e.PaymentId)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentDetails>()
                .Property(e => e.PaymentSatus)
                .IsUnicode(false);

            modelBuilder.Entity<Subscriptions>()
                .HasMany(e => e.BillDetails)
                .WithRequired(e => e.Subscriptions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subscriptions>()
                .HasMany(e => e.CoustomerSubscription)
                .WithRequired(e => e.Subscriptions)
                .WillCascadeOnDelete(false);
        }
    }
}
