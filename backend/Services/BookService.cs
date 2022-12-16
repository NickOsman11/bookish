using Bookish.Models.API;
using Bookish.Models.Database;
using Bookish.Repositories;

namespace Bookish.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book AddBook(AddBookRequest request);
    }
    public class BookService : IBookService
    {
        private readonly IBookRepo books;
        private readonly IAuthorRepo authors;

        public BookService
        (
            IAuthorRepo authorRepo,
            IBookRepo bookRepo
        )
        {
            authors = authorRepo;
            books = bookRepo;
        }

        public Book AddBook(AddBookRequest request)
        {

            authors.GetAuthorsByID(request.AuthorIDs);

            return books.AddBook(request);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return books.GetAllBooks();
        }
        
    }
}