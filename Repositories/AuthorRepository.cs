using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.Model;


namespace task1.Repositories
{
    public enum authorInclude
    {
        news,
        none
    }
    public class AuthorRepository : IAuthorRepository
    {
      
        private readonly Context context;

        public AuthorRepository(Context _context)
        {
            context = _context;
        }

        public void addAuthor(Author author)
        {
            context.Add(author);
        }

        public Author Get(Func< Author,bool> filter , authorInclude AI = authorInclude.none)
        {
            Author author = new Author();
            switch(AI)
            {
                case authorInclude.news:
                    author = context.authors.Include(a=>a.news).FirstOrDefault(filter);
                    break;

                default:
                    author = context.authors.FirstOrDefault(filter);
                    break;
            }
            return author;
        }


        public List<Author> Get() 
        {
          // List <Category> categories = new List<Category>();
            //switch (CI)
            //{
            //    case categoryInclude.products:
            //        category = context.categories.Include(c => c.Products).FirstOrDefault(filter);
            //        break;

            //    default:
            //        category = context.categories.FirstOrDefault(filter);
            //        break;
            //}
            return context.authors.ToList();
        }

        [HttpDelete]
        public void delete(Author author)    
        {
            if(author != null)
            {
                context.authors.Remove(author);
              List<News> news = context.news
                    .Where(n => n.authorId == author.Id).ToList();
                foreach(News n in news)
                {
                    context.news.Remove(n);
                }
            }
        }

        public void save() 
        {
            context.SaveChanges();
        }
    }
}
