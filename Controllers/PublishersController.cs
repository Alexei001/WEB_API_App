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
    }
}
