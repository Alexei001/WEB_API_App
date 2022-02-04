using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using WEB_API_App.Data.Services;
using WEB_API_App.Data.Services.ViewModels;

namespace WEB_API_App.Controllers
{
    public class PublishersController : Base.ControllerBase
    {
        private readonly PublisherServices publisherServices;

        public PublishersController(PublisherServices publisherServices)
        {
            this.publisherServices = publisherServices;
        }


        [HttpPost("Add-Publisher")]
        public IActionResult AddPublisher([FromBody] PublisherViewModel model)
        {
            var returnPub = publisherServices.AddPublisher(model);
            return Created(nameof(AddPublisher), returnPub);
        }
        [HttpGet("Get-All-Publisher")]
        public IActionResult GetAllPublisher()
        {
            var _response = publisherServices.GetAllPublisher();
            if (_response != null)
            {
                return Ok(_response);
            }
            return NotFound();
        }
        [HttpGet("Get-Publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = publisherServices.GetPublisherById(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            return NotFound();
        }


        [HttpGet("Get-Publisher-With-Book-Authors-By-Id/{id}")]
        public IActionResult GetPublisherWithBooksAuthorsById(int id)
        {
            var _response = publisherServices.GetPublisherWithBookAuthorsById(id);

            if (_response != null)
            {
                return Ok(_response);
            }
            return NotFound();

        }

        [HttpDelete("Delete-publisher-by-Id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                publisherServices.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
