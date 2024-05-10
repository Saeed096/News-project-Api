using task1.Model;

namespace task1.Repositories
{
    public interface INewsRepository
    {
        public News GetById(int id);
        public List<News> GetAll();
        public void addNews(News news);
        public void updateNews(News news);
        public void deleteNews(int id);
        public void save();


    }
}