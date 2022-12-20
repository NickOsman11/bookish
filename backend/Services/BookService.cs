using System.Collections.Generic;
using Bookish.Models.API;
using Bookish.Models.Database;
using Bookish.Repositories;

namespace Bookish.Services
{
    public interface IBookService
    {
        IEnumerable<BookResponse> GetAllBooks();
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

            List<Author> bookAuthors = (List<Author>)authors.GetAuthorsByID(request.AuthorIDs);

            Book bookToAdd = new Book
            {
                Title = request.Title,
                Authors = bookAuthors
            };

            return books.AddBook(bookToAdd);
        }

        public IEnumerable<BookResponse> GetAllBooks()
        {
            List<Book> retrivedBooks = books.GetAllBooks().ToList();
            List<BookResponse> bookResponses = new List<BookResponse>();

           foreach (Book book in retrivedBooks)
            {
                BookResponse bookResponse = new BookResponse
                {
                    BookID = book.BookID,
                    Title = book.Title,
                    Authors = new List<BarebonesAuthor>()
                };

                foreach (Author author in book.Authors)
                {
                    bookResponse.Authors.Add(new BarebonesAuthor(author));
                }

                bookResponses.Add(bookResponse);
            };
            
            return bookResponses;
        }
        
    }
}