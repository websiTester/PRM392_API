using PRM392_API.Repositories.Implementation;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Implementation;
using PRM392_API.Services.Interface;

namespace PRM392_API.ProgramConfig
{
	public static class Tan
	{
		public static IServiceCollection AddMyServices3(this IServiceCollection services)
		{
            services.AddScoped<IClassDetailRepository, ClassDetailRepository>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();

            services.AddScoped<IClassDetailService, ClassDetailService>();

            return services;
		}
	}
}
