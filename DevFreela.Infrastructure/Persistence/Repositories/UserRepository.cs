using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DevFreelaDbContext _dbContext;
		private readonly string _connectionString;
		public UserRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
		{
			_dbContext = dbContext;
			_connectionString = configuration.GetConnectionString("DevFreelaCs");
		}
		public async Task<User> GetByIdAsync(int id)
		{
			return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
		}
	}
}
