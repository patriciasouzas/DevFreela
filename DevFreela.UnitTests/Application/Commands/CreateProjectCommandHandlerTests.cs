using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
	public class CreateProjectCommandHandlerTests
	{
		[Fact]
		public async Task InputDataIsOk_Executed_ReturnProjectId()
		{
			//Arrange
			var projectRepositoryMock = new Mock<IProjectRepository>();

			var createProjectCommand = new CreateProjectCommand
			{
				Title = "Formação C#",
				Description = "Curso formação C#",
				TotalCost = 1000,
				IdClient = 1,
				IdFreelancer = 1
			};

			var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMock.Object);

			//Act
			var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

			//Assert
			Assert.True(id >= 0);

			projectRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
		}
	}
}
