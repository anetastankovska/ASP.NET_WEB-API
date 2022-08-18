using BookApi.App.Data;
using BookApi.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.App.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class BooksController : ControllerBase
    {
        public static List<Book> Books { get; set; } = BookRepository.Books;

        [HttpGet("[/getall]")]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(Books);
        }

        [HttpGet("[{id}]")]
        public ActionResult<Book> GetById(int? id)
        {
            var book = Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet()]
    }
}
