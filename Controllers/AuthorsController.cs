using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_App.Data.Services;
using WEB_API_App.Data.Services.ViewModels;

namespace WEB_API_App.Controllers
{

    public class AuthorsController : Base.ControllerBase
    {
        private readonly AuthorServices authorServices;

        public AuthorsController(AuthorServices authorServices)
        {
            this.authorServices = authorServices;
        }

        [HttpPost("Add-Author")]
        public IActionResult AddAuthor([FromBody] AuthorViewModel model)
        {
            authorServices.AddAuthor(model);
            return Ok();
        }

        [HttpGet("Get-All-Authors")]
        public IActionResult GetAllAuthors()
        {
            return Ok(authorServices.GetAllAuthors());
        }


        [HttpGet("Get-Author-by-Id/{id}")]
        public IActionResult GetAuthorByIdWithBooks(int id)
        {
            return Ok(authorServices.GetAuthorByIdWithBooks(id));
        }
    }
}
