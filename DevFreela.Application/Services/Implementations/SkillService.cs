using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations
{
	public class SkillService : ISkillService
	{
		private readonly DevFreelaDbContext _dbContext;
		//private readonly string _connectionString;
		public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
		{
			_dbContext = dbContext;
			//_connectionString = configuration.GetConnectionString("DevFreelaCs");
		}
		public List<SkillViewModel> GetAll()
		{
			/*using var mySqlConnection = new MySqlConnection(_connectionString);
			{
				mySqlConnection.Open();

				var script = "SELECT Id, Description FROM Skills";

				return mySqlConnection.Query<SkillViewModel>(script).ToList();
			}*/
			var skills = _dbContext.Skills;

			var skillsViewModel = skills
				.Select(s => new SkillViewModel(s.Id, s.Description))
				.ToList();

			return skillsViewModel;
		}
	}
}
