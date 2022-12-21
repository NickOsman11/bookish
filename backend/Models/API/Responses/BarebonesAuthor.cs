using Bookish.Models.Database;

namespace Bookish.Models.API
{
    public class BarebonesAuthor
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }

        public BarebonesAuthor (Author author)
        {
            AuthorID = author.AuthorID;
            Name = author.Name;
        }
    }
}
