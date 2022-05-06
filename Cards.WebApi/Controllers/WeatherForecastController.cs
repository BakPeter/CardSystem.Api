using Cards.Dal.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Cards.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICardsDalService _dalService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            ICardsDalService dalService)
        {
            _logger = logger;
            _dalService = dalService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var n = await _dalService.CalculateNumAsync("345");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Num = n 
            })
            .ToArray();
        }
    }
}