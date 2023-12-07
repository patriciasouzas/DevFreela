using System;

namespace DevFreela.Core.Entities
{
	public class Skill
	{
		public Skill(string description)
		{
			Description = description;
			CreatedAt = DateTime.Now;
		}
		public string Description { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public int Id { get; set; }
	}
}
