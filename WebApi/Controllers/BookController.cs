using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<string>> Get()
        {
            var books = _context.book.ToList();
            return Ok(books);
        }
        [HttpGet("findByName/{name}")]
        public ActionResult<IEnumerable<string>> GetByName(string name)
        {
            var books = from b in _context.book
                        where b.Name.Equals(name)
                        select b;
            return Ok(books);
        }
        [HttpGet("findByAuthor/{author}")]
        public ActionResult<IQueryable<string>> GetByAuthor(string author)
        {
            var books = from b in _context.book
                        join a in _context.author on b.Author_idAuthor equals a.idAuthor
                        where b.author.Name.Equals(author)
                        select new {id = b.idBook, name = b.Name, year = b.Year, size = b.Size, author = a.Name};
            return Ok(books);
        }
        [HttpGet("deleteByName/{name}")]
        public ActionResult<IEnumerable<string>> Delete(string name)
        {
            var books = from b in _context.book
                        where b.Name.Equals(name)
                        select b;
            _context.Remove(books);
            _context.SaveChanges();
            return Ok("Книга с названием "+name+ " удалена");
        }
    }
}
