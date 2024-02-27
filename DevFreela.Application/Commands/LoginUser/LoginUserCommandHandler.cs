using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser
{
	public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
	{
		private readonly IAuthService _authService;
		private readonly IUserRepository _userRepository;
		public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
		{
			_authService = authService;
			_userRepository = userRepository;
		}
		public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
		{
			// utilizar mesmo algoritmo para criar hash dessa senha
			var passwordHash = _authService.ComputeSha256Hash(request.Password);

			// buscar no meu banco de dados um user que tenha e-mail e senha em formato hash
			var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

			// se não existir, erro no login
			if (user == null)
			{
				return null;
			}

			// se existir, gera o token usando as informações do usuário
			var token = _authService.GenerateJwtToken(user.Email, user.Role);

			return new LoginUserViewModel(user.Email, token);
		}
	}
}