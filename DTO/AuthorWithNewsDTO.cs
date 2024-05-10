using task1.Model;

namespace task1.DTO
{
    public class AuthorWithNewsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<News> news  { get; set; }   = new List<News>();
    }
}
