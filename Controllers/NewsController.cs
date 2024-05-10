using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using task1.Model;
using task1.Repositories;
using task1.Services;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository newsRepository;
        private readonly IFileService fileService;
        private readonly IWebHostEnvironment webHost;

        public NewsController(INewsRepository _newsRepository, IFileService _fileService, IWebHostEnvironment _webHost)
        {
            newsRepository = _newsRepository;
            fileService = _fileService;
            webHost = _webHost;
        }


        [HttpGet]   // ("{id:int}")     // test !!!!!!!!!
        [Route("id")]  
        public IActionResult GetById(int id)
        {
          News news = newsRepository.GetById(id);
            if(news != null) 
               return Ok(news);

            return BadRequest("invalid id");            
        }


            [HttpGet]
       // [Route("api/products")]
        public IActionResult GetAll() 
            {
                List<News> news = newsRepository.GetAll();
                return Ok(news);
            }

        [HttpPost("saveImage")] 
        public async Task<IActionResult> saveImage()  // unsupported media type 
        {
            string filePath;
            string imageName = "image not added" ;
            var res = false;
            try
            {
                var UploadedFile = Request.Form.Files[0];
                //foreach (var file in UploadedFiles)
                //{
                  //  string filename = UploadedFile.FileName;
                  //  string filepath = getFilepath(UploadedFile.FileName);

                string uploadpath = Path.Combine(webHost.WebRootPath, "img");
                if (!System.IO.Directory.Exists(uploadpath))
                {
                    System.IO.Directory.CreateDirectory(uploadpath);
                }
                 imageName = Guid.NewGuid().ToString() + "-" + UploadedFile.FileName;
                filePath = Path.Combine(uploadpath, imageName);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    using (FileStream stream = System.IO.File.Create(filePath))
                    {
                        await UploadedFile.CopyToAsync(stream);
                        res = true;
                    }
                }
       //     }
            catch
            {

            }
            if (res)
            {
                return Ok(new
                {
                    path = imageName // Assuming imagePath is the variable holding the image path
                });
            }

            else
            {
                return BadRequest();
            }
            //ValidationContext context = new ValidationContext(news);
            //var validationResults = new List<ValidationResult>();
            //bool isValid = Validator.TryValidateObject(news, context, validationResults, true);
            //string resultMsg = "";

            //if (isValid)
            //{
            //    try
            //    {
            //        if(news.imageFile != null)
            //        {
            //          Tuple<int,string> saveResult =
            //                fileService.SaveImage(news.imageFile);

            //            if(saveResult.Item1 == 1)
            //            {
            //                news.image = saveResult.Item2;
            //                newsRepository.addNews(news);
            //                newsRepository.save();
            //                resultMsg = "Added successfully";
            //                return Ok(resultMsg);
            //            }
            //        }
            //        resultMsg = "Error on adding";
            //        //newsRepository.addNews(news);
            //        //newsRepository.save();
            //        // return CreatedAtAction("GetById", new { id = news.id }, news); // how get id >> 0 ????
            //    }
            //    catch (Exception ex) 
            //    {
            //        return BadRequest(ex.Message);
            //    }
            //}
              //var errorMessage = string.Join(", ", validationResults.Select(r => r.ErrorMessage));
              //return BadRequest(errorMessage);
    }

        //[NonAction]
        //public string getFilepath(string name)
        //{
        //    return Path.Combine(this.webHost.WebRootPath + "\\img\\");
        //}

        [HttpPost("add")]
        public IActionResult add([FromBody] News news)
        {
            ValidationContext context = new ValidationContext(news);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(news, context, validationResults, true);
            string resultMsg = "";

            if (isValid)
            {
                try
                {
                    newsRepository.addNews(news);
                    newsRepository.save();
                    return CreatedAtAction("GetById", new { id = news.id }, news); // how get id >> 0 ????
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            var errorMessage = string.Join(", ", validationResults.Select(r => r.ErrorMessage));
            return BadRequest(errorMessage);
        }


        [HttpPut]
        public IActionResult update([FromBody] News updatedNews)             
        {
           News news = newsRepository.GetById(updatedNews.id);
            //ValidationContext context = new ValidationContext(news);
            //var validationResults = new List<ValidationResult>();
            //bool isValid = Validator.TryValidateObject(news, context, validationResults, true);

            if (news != null)
            {
                try
                {
                    newsRepository.updateNews(updatedNews);  // select of update use dif context so 2 dif context try to track same obj ??????   // same obj cannot be tracked by 2 references
                    newsRepository.save();
                    return NoContent();                // returns should be memorized for each action????? no
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
          //  var errorMessage = string.Join(", ", validationResults.Select(r => r.ErrorMessage));
            return BadRequest("error on update");
        }


        [HttpDelete]
        public IActionResult delete(int id) 
        {
            try
            {
                newsRepository.deleteNews(id);
                newsRepository.save();
                return NoContent();
            }
            catch (Exception ex) 
            {
              return BadRequest(ex.Message);
            }
         
        }
    }
}
