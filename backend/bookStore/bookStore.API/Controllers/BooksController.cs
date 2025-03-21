using Microsoft.AspNetCore.Mvc;
using BookStore.Aplication.Services;
using bookStore.API.Contracts;
using BookStore.Core.Models;
namespace bookStore.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksServices _booksServices;

        public BooksController(IBooksServices booksServices)
        {
            _booksServices = booksServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksResponce>>> GetBooks()
        {
            var books = await _booksServices.GetAllBooks();

            var responce = books.Select(b => new BooksResponce(b.Id, b.Title, b.Description, b.Author, b.Price));

            return Ok(responce);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest request)
        {
            var (book, error) = Book.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.Author,
                request.price);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var bookId = await _booksServices.CreateBook(book);

            return Ok(bookId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BooksRequest request)
        {
            var bookId = await _booksServices.UpdateBook(id, request.Title, request.Description, request.Author, request.price);

            return Ok(bookId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            return Ok(await _booksServices.DeleteBook(id));
        }
    }
}
