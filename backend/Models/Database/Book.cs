using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Database
{
    public class Book
    {
        public int BookID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public List<Author> Authors { get; set; }
    }
}