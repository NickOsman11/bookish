using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish
{
    public class BookishContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
            string ConnectionString;
            ConnectionString = Environment.GetEnvironmentVariable("DB_STRING");
            // optionsBuilder.UseNpgsql(ConnectionString);
            optionsBuilder.UseNpgsql("Host=localhost:5432;Database=bookish;Username=bookish;Password=bookish");
         }
    }
}