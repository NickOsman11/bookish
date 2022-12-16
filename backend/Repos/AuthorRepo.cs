using Bookish.Models.API;
using Bookish.Models.Database;

namespace Bookish.Repositories
{
    public interface IAuthorRepo
    {
        Author GetAuthorByID(int ID);
        List<Author> GetAuthorsByID(List<int> IDs);
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
            return context.Authors.Single(a => a.AuthorID == ID);
        }

        public List<Author> GetAuthorsByID(List<int> IDs)
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
