using System.Collections.Generic;

namespace Bookish.Models.Database
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}