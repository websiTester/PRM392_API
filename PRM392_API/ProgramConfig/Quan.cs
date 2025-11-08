using PRM392_API.Repositories.Implementation;
using PRM392_API.Repositories.Interface;
using PRM392_API.Services.Implementation;
using PRM392_API.Services.Interface;

namespace PRM392_API.ProgramConfig
{
    public static class Quan
	{
		public static IServiceCollection AddMyServices1(this IServiceCollection services)
		{
			//Configure services in program.cs here
			services.AddScoped<ITeacherClassRepository, TeacherClassRepository>();
			services.AddScoped<ICourseRepository, CourseRepository>();
			services.AddScoped<ITeacherClassService,TeacherClassService>();
			services.AddScoped<IStudentClassService, StudentClassService>();
			services.AddScoped<IStudentClassRepository, StudentClassRepository>();

			return services;
		}
	}
}
