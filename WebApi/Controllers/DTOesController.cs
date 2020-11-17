using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("dto")]
    [ApiController]
    public class DTOesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DTOesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReaderDTOes
        [HttpGet("reader")]
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
        [HttpGet("author")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var authors = from b in _context.author
                          select new AuthorDTO()
                          {
                              idAuthor = b.idAuthor,
                              Name = b.Name
                          };
            return Ok(authors);
        }

    }
}
