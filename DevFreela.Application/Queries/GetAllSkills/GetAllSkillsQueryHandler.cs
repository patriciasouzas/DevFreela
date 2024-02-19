using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
	public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDto>>
	{
		private readonly ISkillRepository _skillRepository;
		public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
		{
			_skillRepository = skillRepository;
		}
		public async Task<List<SkillDto>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
		{
			return await _skillRepository.GetAll();
		}
	}
}
