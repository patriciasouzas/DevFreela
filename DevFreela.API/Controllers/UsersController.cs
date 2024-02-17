using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetUser;
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
		public async Task<IActionResult> GetById(int id)
		{
			var query = new GetUserQuery(id);
			var user = await _mediator.Send(query);

			if (user == null) return NotFound();

			return Ok(user);
		}

		[HttpPut("{id}/login")]
		public IActionResult Login(int id, [FromBody] LoginModel login)
		{
			return NoContent();
		}
	}
}
