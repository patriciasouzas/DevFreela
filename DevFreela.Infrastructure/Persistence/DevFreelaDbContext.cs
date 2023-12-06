using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
	public class DevFreelaDbContext
	{
		public DevFreelaDbContext()
		{
			Projects = new List<Project>
			{
				new Project("Meu projeto ASPNET Core 1", "Descrição 1", 1, 1, 1000),
				new Project("Meu projeto ASPNET Core 2", "Descrição 2", 1, 1, 3000),
				new Project("Meu projeto ASPNET Core 3", "Descrição 3", 1, 1, 2000)
			};

			Users = new List<User>
			{
				new User("Jennifer", "jennifer@email.com", new System.DateTime(1990, 1, 1)),
				new User("Castro", "castro@email.com", new System.DateTime(1970, 1, 1))
			};

			Skills = new List<Skill>
			{
				new Skill(".NET Core"),
				new Skill("C#"),
				new Skill("SQL")
			};
		}

		public List<Project> Projects { get; set; }
		public List<User> Users { get; set; }
		public List<Skill> Skills { get; set; }
	}
}
