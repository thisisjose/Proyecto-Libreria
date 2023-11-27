using libreria_JSVE.Data.Models.Services;
using libreria_JSVE.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreria_JSVE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allbooks = _booksService.GetAllBks();
            return Ok(allbooks);
        }
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }
        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok(); //AQUI QUEDA EL PRIMER VIDEO DE LA PRACT 3
        }
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            var updateBook = _booksService.UpdateBookByID(id, book);
            return Ok(updateBook); //AQUI QUEDA EL SIGUIENTE VIDEO
        }
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookByID(int id)
        {
            _booksService.DeleteBookByID(id);
            return Ok();
        }

    }
}
