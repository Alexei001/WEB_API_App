using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_App.Data.Services;
using WEB_API_App.Data.Services.ViewModels;

namespace WEB_API_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherServices publisherServices;

        public PublishersController(PublisherServices publisherServices)
        {
            this.publisherServices = publisherServices;
        }


        [HttpPost("Add-Publisher")]
        public IActionResult AddPublisher([FromBody] PublisherViewModel model)
        {
            publisherServices.AddPublisher(model);
            return Ok();
        }

        [HttpGet("Get-Publisher-With-Book-Authors-By-Id/{id}")]
        public IActionResult GetPublisherWithBooksAuthorsById(int id)
        {
            return Ok(publisherServices.GetPublisherWithBookAuthorsById(id));
        }

        [HttpDelete("Delete-publisher-by-Id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            publisherServices.DeletePublisherById(id);
            return Ok();
        }
    }
}
