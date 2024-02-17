using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
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
		public async Task<IActionResult> GetAll(string query)
		{
			var getAllProjectsQuery = new GetAllProjectsQuery(query);

			var projects = await _mediator.Send(getAllProjectsQuery);

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
				new { Id = id },
				command
				);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
		{
			if (command.Description.Length > 200)
			{
				return BadRequest();
			}

			await _mediator.Send(command);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteProjectCommand(id);

			await _mediator.Send(command);

			return NoContent();
		}

		[HttpPost("{id}/comments")]
		public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel inputModel)
		{
			_projectService.CreateComment(inputModel);

			return NoContent();
		}

		[HttpPut("{id}/start")]
		public async Task<IActionResult> Start(int id)
		{
			var command = new StartProjectCommand(id);

			await _mediator.Send(command);

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
