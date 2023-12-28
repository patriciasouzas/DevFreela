using MediatR;

namespace DevFreela.Application.Commands.CreateProject
{
	public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, int>
	{
		public Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
