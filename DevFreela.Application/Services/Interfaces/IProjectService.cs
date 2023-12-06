using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System.Collections.Generic;

namespace DevFreela.Application.Services.Interfaces
{
	public interface IProjectService
	{
		List<ProjectViewModel> GetAll(string query);
		List<DetailsViewModel> GetById(int id);
		int Create(NewProjectInputModel inputModel);
		void Update(UpdateProjectInputModel inputModel);
		void Delete(int id);
		void CreateComment(CreateCommentInputModel inputModel);
		void Star(int id);
		void Finish(int id);
	}
}
