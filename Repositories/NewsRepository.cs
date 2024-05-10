using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.Model;

namespace task1.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly Context context;

        public NewsRepository(Context _context)
        {
            context = _context;
        }

        public News GetById(int id) 
        {
            
          News news = context.news.FirstOrDefault(n => n.id == id);
            if(news != null)
            context.Entry(news).State = EntityState.Detached;       // right???? right
            return news;
        } 

        public List<News> GetAll() 
        {
           return context.news.ToList(); 
        }

        public void addNews(News news)
        {
            context.Add(news);
        }

        public void updateNews(News news) 
        {
           //Product pro = context.products.First(p => p.Id == product.Id);
           // if (pro != null)
                context.Update(news);
           
        }

        public void deleteNews(int id) 
        {
            News news = context.news.First(n => n.id == id);
            context.news.Remove(news);
        }
        public void save()
        {
            context.SaveChanges();
        }
    }

 
}
