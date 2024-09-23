using Microsoft.AspNetCore.Mvc;


// https://learn.microsoft.com/en-us/visualstudio/ide/connect-team-project?view=vs-2019
// https://stackoverflow.com/questions/51851449/in-visual-studio-code-for-windows-the-git-branch-doesnt-show-and-cant-create
// https://git-scm.com/book/en/v2/Git-Branching-Basic-Branching-and-Merging
// https://learn.microsoft.com/en-us/visualstudio/version-control/git-create-branch?view=vs-2022

namespace TestWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Cold", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
