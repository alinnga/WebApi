using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.Data;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return await _context.book.ToListAsync();
        }

        [HttpGet("findByName/{name}")]
        public async Task<ActionResult<Book>> GetByName(string name)
        {
            Book book = await _context.book.FirstOrDefaultAsync(x => x.Name == name);
            if (book == null)
                return NotFound();
            return new ObjectResult(book);
        }
        [HttpGet("findByAuthor/{author}")]
        public ActionResult<IQueryable<string>> GetByAuthor(string author)
        {
            var books = from b in _context.book
                        join a in _context.author on b.Author_idAuthor equals a.idAuthor
                        where b.author.Name.Equals(author)
                        select new { id = b.idBook, name = b.Name, year = b.Year, size = b.Size, author = a.Name };
            return Ok(books);
        }
        [HttpGet("deleteByName/{name}")]
        public ActionResult<IEnumerable<string>> Delete(string name)
        {
            Book book = _context.book.FirstOrDefault(p => p.Name == name);
            _context.Remove(book);
            _context.SaveChanges();
            return Ok("Книга с названием " + name + " удалена");
        }
        [HttpDelete("{name}")]
        public async Task<ActionResult<Book>> Delete1(string name)
        {
            Book book = _context.book.FirstOrDefault(p => p.Name == name);
            if(book == null)
            {
                return NotFound();
            }
            _context.book.Remove(book);
             await _context.SaveChangesAsync();
            return Ok(book);
        }
        [HttpPut]
        public async Task<ActionResult<Book>> Put(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            if (!_context.book.Any(x => x.idBook == book.idBook))
            {
                return NotFound();
            }

            _context.Update(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            _context.book.Add(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }
    }
}
