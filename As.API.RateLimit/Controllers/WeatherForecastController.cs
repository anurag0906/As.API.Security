using Microsoft.AspNetCore.Mvc;
using NWebsec.AspNetCore.Core.Web;

namespace As.API.RateLimit.Controllers
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

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}

	//	[Obsolete]
	//	public static string GetClientIpAddress(this HttpRequestMessage request)
	//	{
	//		const string HttpContext = "MS_HttpContext";
	//		const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";

	//		if (request.Properties.ContainsKey(HttpContext))
	//		{
	//			dynamic ctx = request.Properties[HttpContext];
	//			if (ctx != null)
	//			{
	//				return ctx.Request.UserHostAddress;
	//			}
	//		}

	//		if (request.Properties.ContainsKey(RemoteEndpointMessage))
	//		{
	//			dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
	//			if (remoteEndpoint != null)
	//			{
	//				return remoteEndpoint.Address;
	//			}
	//		}

	//		return null;
	//	}

		//public IActionResult Index()
		//{
		//	string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
		//}
	}
}