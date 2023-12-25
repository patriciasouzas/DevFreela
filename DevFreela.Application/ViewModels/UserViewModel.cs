namespace DevFreela.Application.ViewModels
{
	public class UserViewModel
	{
		public UserViewModel(string fullname, string email)
		{
			FullName = fullname;
			Email = email;
		}

		public string FullName { get; private set; }
		public string Email { get; private set; }
	}
}
