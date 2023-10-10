using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace As.API.Security.HttpsOnly.Controllers
{
	[EnableCors("MyCorsPolicy")]
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		// GET: api/<HomeController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "test", "value2" };
		}

		// GET api/<HomeController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<HomeController>
		[HttpPost]
		public string Post([FromBody] string value)
		{
			return "You posted- " + value;
		}

		// PUT api/<HomeController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<HomeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
