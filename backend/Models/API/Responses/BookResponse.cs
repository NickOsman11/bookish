namespace Bookish.Models.API
{
    public class BookResponse
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public List<BarebonesAuthor> Authors { get; set; }
    }
}