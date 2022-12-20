using System.Collections.Generic;
using System.Linq;
using Bookish.Models.API;
using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories
{
    public interface IBookRepo
    {
        IEnumerable<Book> GetAllBooks();
        Book AddBook(Book bookToAdd);
    }

    public class BookRepo : IBookRepo
    {
        private readonly BookishContext context;

        public BookRepo
        (
            BookishContext bookishContext
        )
        {
            context = bookishContext;
        }

        public Book AddBook(Book bookToAdd)
        {
            var addedBook = context.Books.Add(bookToAdd);
            context.SaveChanges();

            return addedBook.Entity;
        }

        public IEnumerable<Book> GetAllBooks()
        {

            List<Book> books = context.Books
                .Include(book => book.Authors)
                .ToList();

            return books;
        }

    }
}
