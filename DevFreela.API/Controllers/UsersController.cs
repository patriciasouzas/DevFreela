using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
	[Route("api/users")]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;
		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		//api/users
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
		{
			var id = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = id }, command);
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
