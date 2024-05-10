using System.ComponentModel.DataAnnotations;

namespace task1.Model
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required") , 
        StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters")]
        public string name { get; set; }
        public List<News>? news { get; set; } 
    }
}
