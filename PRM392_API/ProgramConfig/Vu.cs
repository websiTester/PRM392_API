using PRM392_API.Repositories.Implementation;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Implementation;
using PRM392_API.Services.Interface;

namespace PRM392_API.ProgramConfig
{
	public static class Vu
	{
		public static IServiceCollection AddMyServices5(this IServiceCollection services)
		{
            services.AddScoped<IGradingRepository, GradingRepository>();
            services.AddScoped<IGradingService, GradingService>();
            services.AddScoped<IDashboardService, DashboardService>();
			services.AddScoped<IDashboardRepository, DashboardRepository>();

			return services;
		}
	}
}
