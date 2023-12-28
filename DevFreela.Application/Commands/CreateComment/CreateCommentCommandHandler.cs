using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
	public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
	{
		private readonly DevFreelaDbContext _dbContext;
		public CreateCommentCommandHandler(DevFreelaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
		{
			var comment = new ProjectComment(
				request.Content,
				request.IdProject,
				request.IdUser
				);

			await _dbContext.ProjectComments.AddAsync(comment);
			await _dbContext.SaveChangesAsync();
		}
	}
}
