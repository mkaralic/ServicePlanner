using Microsoft.AspNetCore.Mvc;
using ServicePlanner.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace ServicePlanner.WebUI.Controllers;
public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
