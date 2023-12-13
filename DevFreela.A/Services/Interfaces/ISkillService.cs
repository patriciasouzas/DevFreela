using DevFreela.Application.ViewModels;
using System.Collections.Generic;

namespace DevFreela.Application.Services.Interfaces
{
	public interface ISkillService
	{
		List<SkillViewModel> GetAll();
	}
}
