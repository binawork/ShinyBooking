using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShinyBooking.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
        }
        
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //await AddRoles();
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        //
        // public async Task AddRoles()
        // {
        //     var rolesList = new List<string>
        //     {
        //         "Member",
        //         "Owner",
        //         "Admin"
        //     };
        //
        //     foreach (var role in rolesList)
        //     {
        //         var roleExist = await _roleManager.RoleExistsAsync(role);
        //
        //         if (!roleExist)
        //             await _roleManager.CreateAsync(new IdentityRole(role));
        //     }
        // }
    }
}
