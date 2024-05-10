namespace task1.Services
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);

    }
}
