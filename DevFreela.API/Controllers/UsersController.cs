using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
	[Route("api/users")]
	public class UsersController : ControllerBase
	{
		[HttpPost]
		public IActionResult Post([FromBody] CreateUserModel createUserModel)
		{
			return CreatedAtAction(nameof(GetById), new { id = 1 }, createUserModel);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			return Ok();
		}

		[HttpPut("{id}/login")]
		public IActionResult Login(int id, [FromBody] LoginModel login)
		{
			return NoContent();
		}
	}
}
