using Bookish.Models.API;
using Bookish.Models.Database;

namespace Bookish.Repositories
{
    public interface IBookRepo
    {
        IEnumerable<Book> GetAllBooks();
        Book AddBook(AddBookRequest request);
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

        public Book AddBook(AddBookRequest request)
        {
            List<Author> authors = new List<Author>();

            foreach (int ID in request.AuthorIDs)
            {
                authors.Add(context.Authors.Single(a => a.AuthorID == ID));
            }
            
            Book bookToAdd = new Book
            {
                Title = request.Title,
                Authors = authors
            };

            var addedBook = context.Books.Add(bookToAdd);
            context.SaveChanges();

            return addedBook.Entity;
        }

        public IEnumerable<Book> GetAllBooks()
        {

            List<Book> books = context.Books.ToList();

            return books;
        }

    }
}
