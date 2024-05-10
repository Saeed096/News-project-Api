using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task1.Attributes;

namespace task1.Model
{
    public class News 
    {
        public int id { get; set; }
     
        public string title { get; set; }
        public string news { get; set; }
        public string? image { get; set; }
        [NotMapped]
        public IFormFile? imageFile { get; set; } 



        [PublicationDateValidationAttribute]
        public DateTime publicationDate { get; set; } 
        public DateTime creationDate { get; private set; } = DateTime.Now;
        [ForeignKey("author")] 
        public int authorId { get; set; } 
        public Author? author { get; set; }

    }
}
