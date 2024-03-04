using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core.Entities
{
	public class ProjectTests
	{
		[Fact]
		public void TestIfProjectStartWorks()
		{
			var project = new Project("Curso C#", "Curso formação C#", 1, 2, 1000);

			Assert.Equal(ProjectStatusEnum.Created, project.Status);
			Assert.Null(project.StartedAt);

			Assert.NotNull(project.Title);
			Assert.NotEmpty(project.Title);

			Assert.NotNull(project.Description);
			Assert.NotEmpty(project.Description);

			project.Start();

			Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
			Assert.NotNull(project.StartedAt);
		}
	}
}
