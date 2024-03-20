using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
	public class GetAllProjectsCommandHandlerTests
	{
		[Fact]
		public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
		{
			//Arrange
			var projects = new List<Project>
			{
				new Project("Formação C#", "Curso de Formação", 1, 1, 1000),
				new Project("Formação Java", "Curso de Formação", 1, 1, 2000),
				new Project("Formação Python", "Curso de Formação", 1, 1, 3000)
			};

			var projectRepositoryMock = new Mock<IProjectRepository>();
			projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

			var getAllProjectsQuery = new GetAllProjectsQuery("");
			var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

			//Act
			var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

			//Assert
			Assert.NotNull(projectViewModelList);
			Assert.NotEmpty(projectViewModelList);
			Assert.Equal(projects.Count, projectViewModelList.Count);

			projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
		}
	}
}
