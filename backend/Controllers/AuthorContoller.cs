using System.Collections.Generic;
using Bookish.Exceptions;
using Bookish.Models.API;
using Bookish.Models.Database;
using Bookish.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    [ApiController]
    [Route("authors")]

    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authors;

        public AuthorController
        (
            IAuthorService authorsService
        )
        {
            authors = authorsService;
        }
        [HttpGet]
        [Route("bb")]
        public IEnumerable<BarebonesAuthor> GetAllBarebonesAuthors() 
        {
            return authors.GetAllBarebonesAuthors();
        }

    }
}