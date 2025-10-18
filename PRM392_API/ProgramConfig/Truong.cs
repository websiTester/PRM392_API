using PRM392_API.Repositories.Implementation;
using PRM392_API.Repositories.Interface;

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
