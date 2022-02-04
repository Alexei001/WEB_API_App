using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_App.Data.Services;
using WEB_API_App.Data.Services.ViewModels;

namespace WEB_API_App.Controllers
{

    public class BooksController : Base.ControllerBase
    {
        protected readonly BookServices _bookServices;
        public BooksController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpPost("Add-Book-With-Authors")]
        public IActionResult AddBookWithAuthors([FromBody] BookViewModel model)
        {
            _bookServices.AddBookWithAuthors(model);
            return Ok();
        }

        [HttpGet("Get-All-Books")]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookServices.GetAllBooks());
        }


        [HttpGet("Get-All-Books/{id}")]
        public IActionResult GetBookById(int id)
        {
            return Ok(_bookServices.GetBookById(id));
        }

        [HttpPut("Update-Books-By-Id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookViewModel model)
        {
            return Ok(_bookServices.UpdateBookById(id, model));
        }
        [HttpDelete("Delete-Books-By-Id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            return Ok(_bookServices.DeleteBookById(id));
        }


    }
}
