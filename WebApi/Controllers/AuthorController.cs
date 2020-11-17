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
    public class AuthorController : ControllerBase
    {
        private ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var readers = _context.author.ToList();
            return Ok(readers);
        }
    }
}
