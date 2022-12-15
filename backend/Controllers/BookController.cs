using Bookish.Models.API;
using Bookish.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    [ApiController]
    [Route("books")]

    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<BookResponse> GetAllBooks()
        {
            var context = new BookishContext();

            Book BookToAdd = new Book();

            BookToAdd.Title = "The Bible";

            context.Books.Add(BookToAdd);
            context.SaveChanges();

            List<BookResponse> books = new List<BookResponse>
            {
                new BookResponse
                {
                    BookID = 1,
                    Title = "For Whom the Bell Tolls"
                },
                new BookResponse
                {
                    BookID = 2,
                    Title = "The Count of Monte Cristo"
                },
            };



            return books;
        }
    }
}