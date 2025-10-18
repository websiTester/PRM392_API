namespace PRM392_API.Repository.Interfaces
{
	public interface IAccountRepository
	{
		public bool Login(string username, string password);
	}
}
