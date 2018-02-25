namespace BookStore.Data
{
    using BookStore.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        // public DbSet<BookCategory> BookCategory { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            builder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            builder.Entity<Book>()
                .HasMany(b => b.Categories)
                .WithOne(c => c.Book)
                .HasForeignKey(c => c.BookId);

            builder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);

            base.OnModelCreating(builder);
        }        
    }
}
