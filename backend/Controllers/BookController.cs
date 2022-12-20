using System.Collections.Generic;
using Bookish.Exceptions;
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
        public IEnumerable<BookResponse> GetAllBooks()
        {
            return books.GetAllBooks();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Book> AddBook(AddBookRequest request)
        {
            try
            {
                return books.AddBook(request);  
            }
            catch (EntityNotInDbException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}