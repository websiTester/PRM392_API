using PRM392_API.MyProfile;
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
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<GroupTaskProfile>();
				cfg.AddProfile<UserProfile>();
				cfg.AddProfile<PeerReviewProfile>();
				cfg.AddProfile<AssignmentSubmissionProfile>();
				cfg.AddProfile<FCMTokenProfile>();
            });

            services.AddScoped<IGroupTaskRepository,GroupTaskRepository>();
			services.AddScoped<IGroupTaskService,GroupTaskService>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IPeerReviewRepository, PeerReviewRepository>();
			services.AddScoped<IPeerReviewService, PeerReviewService>();
			services.AddScoped<IAssignmentSubmissionRepository, AssignmentSubmissionRepository>();
			services.AddScoped<IAssignmentSubmissionService, AssignmentSubmissionService>();
			services.AddScoped<IFCMTokenRepository, FCMTokenRepository>();
			services.AddScoped<IFCMTokenService, FCMTokenService>();
            return services;
		}
	}
}
