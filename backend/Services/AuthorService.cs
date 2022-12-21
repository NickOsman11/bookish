using System.Collections.Generic;
using Bookish.Models.API;
using Bookish.Models.Database;
using Bookish.Repositories;

namespace Bookish.Services
{
    public interface IAuthorService
    {
        IEnumerable<BarebonesAuthor> GetAllBarebonesAuthors();
    }
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepo authors;

        public AuthorService
        (
            IAuthorRepo authorRepo
        )
        {
            authors = authorRepo;
        }

        public IEnumerable<BarebonesAuthor> GetAllBarebonesAuthors() 
        {
            List<BarebonesAuthor> response = new List<BarebonesAuthor>();
            List<Author> retrivedAuthors = authors.GetAllAuthors().ToList();
            
            foreach (Author author in retrivedAuthors)
            {
                response.Add(new BarebonesAuthor(author));
            }

            return response;
        }
        
    }
}