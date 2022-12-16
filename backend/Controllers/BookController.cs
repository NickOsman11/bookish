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
        private readonly IBookService bookService;

        public BookController(ILogger<BookController> logger)
        {
            bookService = new BookService();
        }

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return bookService.GetAllBooks();
        }

        [HttpPost]
        [Route("add")]
        public Book AddBook(AddBookRequest request)
        {
            return bookService.AddBook(request);
        }
    }
}