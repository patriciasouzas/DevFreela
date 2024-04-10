using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
	public class ProjectRepository : IProjectRepository
	{
		private readonly DevFreelaDbContext _dbContext;
		private readonly string _connectionString;
		public ProjectRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
		{
			_dbContext = dbContext;
			_connectionString = configuration.GetConnectionString("DevFreelaCs");
		}

		public async Task<List<Project>> GetAllAsync()
		{
			return await _dbContext.Projects.ToListAsync();
		}

		public async Task<Project> GetDetailsByIdAsync(int id)
		{
			return await _dbContext.Projects
				.Include(p => p.Client)
				.Include(p => p.Freelancer)
				.SingleOrDefaultAsync(p => p.Id == id);
		}

		public async Task AddAsync(Project project)
		{
			await _dbContext.Projects.AddAsync(project);
			await _dbContext.SaveChangesAsync();
		}

		public async Task StartAsync(Project project)
		{
			using (var mySqlConnection = new MySqlConnection(_connectionString))
			{
				mySqlConnection.Open();

				var script = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE IdProject = @id";

				await mySqlConnection.ExecuteAsync(script, new { status = project.Status, startedAt = project.StartedAt, project.Id });
			}
		}

		public async Task AddCommentAsync(ProjectComment projectComment)
		{
			await _dbContext.ProjectComments.AddAsync(projectComment);
			await _dbContext.SaveChangesAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Project> GetByIdAsync(int id)
		{
			return await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);
		}
	}
}
