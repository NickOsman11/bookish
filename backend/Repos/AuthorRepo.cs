using Bookish.Exceptions;
using Bookish.Models.API;
using Bookish.Models.Database;
using System.Collections.Generic;
using System.Linq;


namespace Bookish.Repositories
{
    public interface IAuthorRepo
    {
        Author GetAuthorByID(int ID);
        IEnumerable<Author> GetAuthorsByID(List<int> IDs);
    }

    public class AuthorRepo : IAuthorRepo
    {
        private readonly BookishContext context;

        public AuthorRepo
        (
            BookishContext bookishContext
        )
        {
            context = bookishContext;
        }

        public Author GetAuthorByID(int ID)
        {
            try
            {
                Author author = context.Authors.Single(a => a.AuthorID == ID);
                return author;
            }
            catch (InvalidOperationException)
            {
                throw new EntityNotInDbException($"The database does not contain an author with ID {ID}");
            }
        }

        public IEnumerable<Author> GetAuthorsByID(List<int> IDs)
        {
            List<Author> authors = new List<Author>();

            foreach (int ID in IDs)
            {
                authors.Add(GetAuthorByID(ID));
            }

            return authors;
        }
    }
}
