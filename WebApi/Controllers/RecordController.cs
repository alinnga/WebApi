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
    public class RecordController : ControllerBase
    {
        private ApplicationDbContext _context;

        public RecordController(ApplicationDbContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var records = _context.record.ToList();
            return Ok(records);
        }
        [HttpPost]
        public string Post([FromBody]string value)
        {
            return value + "test";
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> GetById(int id)
        {
            var readers = from c in _context.record
                          where c.idRecord == id
                          select c;
            return Ok(readers);
        }
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<string>> Delete(int id)
        {
            var records = from c in _context.record
                          where c.idRecord == id
                          select c;
            _context.Remove(records);
            return Ok(records+" Строки удалены");
        }
    }
}

