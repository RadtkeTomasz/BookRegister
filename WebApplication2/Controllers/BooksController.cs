using BookRegister.Domain;
using BookRegister.Infrastructure.DataPersistence;
using BookRegister.Infrastructure.DataTransferObjects;
using BookRegister.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookRegister.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository repo)
        {
            _bookRepository = repo;
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
          if (_bookRepository.GetAllBooks() == null)
          {
              return NotFound();
          }
            return Ok(_bookRepository.GetAllBooks());
        }

        // GET: api/Books/5
        [HttpGet("{isbn}")]
        public IActionResult GetBook(int isbn)
        {
          if (!_bookRepository.BookExists(isbn))
          {
              return NotFound();
          }
            var book = _bookRepository.GetBook(isbn);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // PUT: api/Books/5
        [HttpPut("{isbn}")]
        public IActionResult UpdateBook(BookDTO dto)
        {
            if (ModelState.IsValid && _bookRepository.UpdateBook(dto))
            {
                return Ok();
            }
            return BadRequest();
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.AddBook(book);
                return CreatedAtAction("GetBook", new { id = book.ISBN }, book);
            }
            return BadRequest();
        }

        // DELETE: api/Books/5
        [HttpDelete("{isbn}")]
        public IActionResult DeleteBook(int isbn)
        {
            if (!_bookRepository.BookExists(isbn))
            {
                return NotFound();
            }

            _bookRepository.DeleteBook(isbn);

            return NoContent();
        }
    }
}
