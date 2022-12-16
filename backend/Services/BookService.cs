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
        private readonly IBookRepo bookRepo;
        private readonly IAuthorRepo authorRepo;

        public BookService()
        {
            bookRepo = new BookRepo();
            authorRepo = new AuthorRepo();
        }

        public Book AddBook(AddBookRequest request)
        {

            authorRepo.GetAuthorsByID(request.AuthorIDs);

            return bookRepo.AddBook(request);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return bookRepo.GetAllBooks();
        }
        
    }
}