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
    }
}
