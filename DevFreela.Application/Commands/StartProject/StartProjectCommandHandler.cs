using Dapper;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace DevFreela.Application.Commands.StartProject
{
	public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
	{
		private readonly DevFreelaDbContext _dbContext;
		private readonly string _connectionString;
		public StartProjectCommandHandler(DevFreelaDbContext dbContext, IConfiguration configuration)
		{
			_dbContext = dbContext;
			_connectionString = configuration.GetConnectionString("DevFreelaCs");
		}

		public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
		{
			var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == request.Id);

			project.Start();

			using (var mySqlConnection = new MySqlConnection(_connectionString))
			{
				mySqlConnection.Open();

				var script = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE Id = @id";

				mySqlConnection.Execute(script, new { status = project.Status, startedAt = project.StartedAt, request.Id });
			}

			return Unit.Value;
		}
	}
}
