using System.Collections.Generic;

namespace Bookish.Models.Database
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
    }
}