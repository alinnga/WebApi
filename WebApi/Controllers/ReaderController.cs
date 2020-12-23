using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReaderController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ReaderController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet("dto")]
        public ActionResult<IEnumerable<string>> Get1()
        {
            var readers = from b in _context.reader
                          select new ReaderDTO()
                          {
                              idReader = b.idReader,
                              Name = b.Name
                          };
            return Ok(readers);
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var readers = _context.reader.ToList();
            return Ok(readers);
        }
        [HttpGet("findByName/{name}")]
        public ActionResult<IEnumerable<string>> GetByName(string name)
        {
            var readers = from b in _context.reader
                        where b.Name.Equals(name)
                        select b;
            return Ok(readers);
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
            Reader reader = _context.reader.FirstOrDefault(p => p.Name == name);
            _context.Remove(reader);
            _context.SaveChanges();
            return Ok("Читатель с именем " + name + " удален");
        }
        [HttpDelete("{name}")]
        public void Delete1(string name)
        {
            Reader reader = _context.reader.FirstOrDefault(p => p.Name == name);
            _context.Remove(reader);
            _context.SaveChanges();
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            Reader reader = _context.reader.FirstOrDefault(p => p.idReader == id);
            reader.Name = name;
            _context.SaveChanges();
        }
        [HttpPost]
        public void Post([FromBody]Reader data)
        {
            Reader reader = new Reader
            {
                Name = data.Name,
                Address = data.Address,
                PhoneNumber = data.PhoneNumber
            };
            _context.reader.Add(reader);
            _context.SaveChanges();
        }
    }
}
