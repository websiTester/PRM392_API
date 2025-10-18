using PRM392_API.Repositories.Implementation;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Implementation;
using PRM392_API.Services.Interface;

namespace PRM392_API.ProgramConfig
{
	public static class Son
	{
		public static IServiceCollection AddMyServices2(this IServiceCollection services)
		{
            services.AddScoped<IGroupTaskRepository,GroupTaskRepository>();
			services.AddScoped<IGroupTaskService,GroupTaskService>();
            return services;
		}
	}
}
