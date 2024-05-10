using Microsoft.AspNetCore.Mvc;
using task1.Model;
using static task1.Repositories.AuthorRepository;

namespace task1.Repositories
{
    public interface IAuthorRepository
    {

        public Author Get(Func<Author, bool> filter, authorInclude AI);
        public List<Author> Get();
        public void addAuthor(Author author);
        public void delete(Author author);
        public void save(); 


    }
}