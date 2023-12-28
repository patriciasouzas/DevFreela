using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
	[Route("/api/projects")]
	public class ProjectsController : ControllerBase
	{
		private readonly IProjectService _projectService;
		private readonly IMediator _mediator;
		public ProjectsController(IProjectService projectService, IMediator mediator)
		{
			_projectService = projectService;
			_mediator = mediator;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult GetAll(string query)
		{
			var projects = _projectService.GetAll(query);

			return Ok(projects);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var project = _projectService.GetById(id);

			if (project == null)
			{
				return NotFound();
			}

			return Ok(project);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
		{
			if (command.Title.Length > 50)
			{
				return BadRequest();
			}

			var id = await _mediator.Send(command);

			return CreatedAtAction
				(
				nameof(GetById),
				new { id = id },
				command
				);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
		{
			if (inputModel.Description.Length > 200)
			{
				return BadRequest();
			}

			_projectService.Update(inputModel);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_projectService.Delete(id);

			return NoContent();
		}

		[HttpPost("{id}/comments")]
		public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel inputModel)
		{
			_projectService.CreateComment(inputModel);

			return NoContent();
		}

		[HttpPut("{id}/start")]
		public IActionResult Start(int id)
		{
			_projectService.Star(id);

			return NoContent();
		}

		[HttpPut("{id}/finish")]
		public IActionResult Finish(int id)
		{
			_projectService.Finish(id);

			return NoContent();
		}
	}
}
