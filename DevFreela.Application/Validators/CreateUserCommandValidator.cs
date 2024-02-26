using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
	public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
	{
		public CreateUserCommandValidator()
		{
			RuleFor(p => p.Email)
				.NotEmpty()
				.EmailAddress()
				.WithMessage("E-mail não válido!");

			RuleFor(p => p.Password)
				.Must(ValidPassword)
				.WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula e um caracter especial.");

			RuleFor(p => p.FullName)
				.NotNull()
				.NotEmpty()
				.WithMessage("Nome é obrigatório.");
		}

		public bool ValidPassword(string password)
		{
			var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

			return regex.IsMatch(password);
		}
	}
}
