using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
	public class SkillRepository : ISkillRepository
	{
		private readonly string _connectionString;
		public SkillRepository(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DevFreelaCs");
		}
		public async Task<List<SkillDto>> GetAll()
		{
			using var mySqlConnection = new MySqlConnection(_connectionString);
			{
				mySqlConnection.Open();

				var script = "SELECT Id, Description FROM Skills";

				var skills = await mySqlConnection.QueryAsync<SkillDto>(script);

				return skills.ToList();
			}
		}
	}
}
