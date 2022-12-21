using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.API
{
    public class AddBookRequest
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageURL { get; set; }     
        [Required]
        public List<int> AuthorIDs { get; set; }
    }
}