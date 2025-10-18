using PRM392_API.Repository.Implementations;
using PRM392_API.Repository.Interfaces;

namespace PRM392_API.ProgramConfig
{
	public static class Truong
	{
		public static IServiceCollection AddMyServices4(this IServiceCollection services)
		{
			//Configure services in program.cs here
			services.AddScoped<IAccountRepository, AccountRepository>();

			return services;
		}
	}
}
