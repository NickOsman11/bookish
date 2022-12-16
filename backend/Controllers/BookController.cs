using Bookish.Models.API;
using Bookish.Models.Database;
using Bookish.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    [ApiController]
    [Route("books")]

    public class BookController : ControllerBase
    {
        private readonly IBookService books;

        public BookController(IBookService bookService)
        {
            books = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return books.GetAllBooks();
        }

        [HttpPost]
        [Route("add")]
        public Book AddBook(AddBookRequest request)
        {
            return books.AddBook(request);
        }
    }
}