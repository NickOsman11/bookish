using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish
{
    public class BookishContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost:5432;Database=bookish;Username=bookish;Password=bookish");
        }
    }
}
