namespace PRM392_API.Repositories.Interface
{
	public interface IAccountRepository
	{
		public bool Login(string username, string password);
	}
}
