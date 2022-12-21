using System.Collections.Generic;

namespace Bookish.Models.API
{
    public class AddBookRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageURL { get; set; }
        public List<int> AuthorIDs { get; set; }
    }
}