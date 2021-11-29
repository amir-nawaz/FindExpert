using Microsoft.AspNetCore.Mvc;

namespace FindExpert.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        public static string abc = "inital search expert";

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ActionName("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForCast()
        {
            abc = "Changed First Time";
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [ActionName("GetAbcSeondValue")]
        [HttpGet]
        public String GetAbcSecondValue()
        {
            abc = "Changed Second Time";
            return "Value Changed";
        }

        [HttpGet]
        [ActionName("GetAbcString")]
        public String GetAbcString()
        {
            // a = abc;
            return abc;
        }

        [HttpGet("{queryParam}")]
        [ActionName("GetAbcString")]
        public String GetAbcString(String queryParam)
        {
            abc = queryParam;
            return abc;
        }


        [HttpPost]
        [ActionName("setAbcString")]
        public String setAbcString(String a)
        {
            abc = a;
            return abc;
        }
    }
}