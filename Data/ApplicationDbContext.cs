using Microsoft.EntityFrameworkCore;
using WEB_API_App.Data.Models;

namespace WEB_API_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books_Authors)
                .HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(a => a.Books_Authors)
                .HasForeignKey(b => b.BookId);


        }


    }
}
