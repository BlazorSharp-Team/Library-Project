using Library_Project.Data;
using Library_Project.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooks _IBooks;
        public BookController(IBooks iBook)
        {
            _IBooks = iBook;
        }
        [HttpGet]
        public async Task<List<Books>> Get()
        {
            return await Task.FromResult(_IBooks.GetBookDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Books book = _IBooks.GetBookData(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Books book)
        {
            _IBooks.AddBook(book);
        }
        [HttpPut]
        public void Put(Books book)
        {
            _IBooks.UpdateBookDetails(book);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IBooks.DeleteBook(id);
            return Ok();
        }
    }
}
