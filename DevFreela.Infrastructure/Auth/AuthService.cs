using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace DevFreela.Infrastructure.Auth
{
	public class AuthService : IAuthService
	{
		private readonly IConfiguration _configuration;
		public AuthService(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GenerateJwtToken(string email, string role)
		{
			var issuer = _configuration["Jwt:Issuer"];
			var audience = _configuration["Jwt:Audience"];
			var key = _configuration["Jwt:Key"];

			var secutirtyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
		}
	}
}
