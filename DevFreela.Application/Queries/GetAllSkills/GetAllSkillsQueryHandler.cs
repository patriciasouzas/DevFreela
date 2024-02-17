using Dapper;
using DevFreela.Application.ViewModels;
using MediatR;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DevFreela.Application.Queries.GetAllSkills
{
	public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
	{
		//private readonly DevFreelaDbContext _dbContext;
		private readonly string _connectionString;
		public GetAllSkillsQueryHandler(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DevFreelaCs");
		}
		public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
		{
			using var mySqlConnection = new MySqlConnection(_connectionString);
			{
				mySqlConnection.Open();

				var script = "SELECT Id, Description FROM Skills";

				var skills = await mySqlConnection.QueryAsync<SkillViewModel>(script);

				return skills.ToList();
			}
		}
	}
}
