using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_App.Data.Services;
using WEB_API_App.Data.Services.ViewModels;

namespace WEB_API_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
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
    }
}
