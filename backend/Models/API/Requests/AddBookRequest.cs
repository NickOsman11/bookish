namespace Bookish.Models.API
{
    public class AddBookRequest
    {
        public string Title { get; set; }
        public List<int> AuthorIDs { get; set; }
    }
}