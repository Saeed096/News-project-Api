using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using task1.DTO;
using task1.Model;
using task1.Repositories;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorController(IAuthorRepository _authorRepository) 
        {
            authorRepository = _authorRepository;
        }
       

        [HttpPost]
        public IActionResult addAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    authorRepository.addAuthor(author);
                    authorRepository.save();
                    return CreatedAtAction("GetById", new { id = author.Id }, author); // how get id >> 0 ????
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();

        }



        [HttpGet]
        //   [Authorize] 
        [Route("id")] 
        public ActionResult GetById(int id)    // send as query string  >> if route attr >> send as segment >> any comp.. send in body except u said [fromhead] or from.....
        {
           Author author = authorRepository.Get(a => a.Id == id , authorInclude.none);
            return Ok(author);
        }


        [HttpGet]
     //   [Authorize]
        public ActionResult Get()  
        {
            List<Author> authors = authorRepository.Get();
            if (authors != null)
            {
                AuthorWithNewsDTO authorsWithNewsDTO = new AuthorWithNewsDTO();

                return Ok(authors);
            }

            return BadRequest("Invalid Id");
        }

        [HttpDelete]
        public IActionResult delete(int id)
        {
           
                try
                {
                    Author author = authorRepository.Get(a => a.Id == id, authorInclude.none);
                    authorRepository.delete(author);
                    authorRepository.save();
                    return Ok(author); 
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            
            
        }


        [HttpPut, Route("update")]
        public IActionResult update(Author author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Author tempAuthor = 
                        authorRepository.Get(a => a.Id == author.Id, authorInclude.none);
                    tempAuthor.name = author.name;
                    authorRepository.save();
                    return Ok("Updated"); 
                }
                catch (Exception ex) 
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();

        }
    }
}
