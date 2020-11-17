using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Data;

namespace WebApi.Controllers
{
    public class WeatherForecastController : ControllerBase
    {
        private ApplicationDbContext _context;

        public WeatherForecastController(ApplicationDbContext context)
        {
            this._context = context;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;


        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(1);
        }
    }
}
