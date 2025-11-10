using FirebaseAdmin.Messaging;
using Microsoft.Extensions.DependencyInjection;
using PRM392_API.Models;
using PRM392_API.Services.Interface;

namespace PRM392_API.MyBackgroundService
{
    public class DeadlineReminderService : BackgroundService
    {
        private readonly ILogger<DeadlineReminderService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public DeadlineReminderService(ILogger<DeadlineReminderService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("DeadlineReminderService running at: {time}", DateTimeOffset.Now);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var _fcmTokenService = scope.ServiceProvider.GetRequiredService<IFCMTokenService>();
                    var _firebaseMessaging = scope.ServiceProvider.GetRequiredService<FirebaseMessaging>();


                    var upcomingAssignments = await _fcmTokenService.GetAssignmentsNearingDeadline(TimeSpan.FromHours(24));

                    foreach (var assignment in upcomingAssignments)
                    {
                        int classId = assignment.ClassId ?? 0;
                        if (classId == 0) continue;
                        var tokens = await _fcmTokenService.GetTokensFromFirebaseAsync(classId);
                        if (tokens == null || !tokens.Any()) continue;

                        var outOfDateMessage = new MulticastMessage()
                        {
                            Notification = new FirebaseAdmin.Messaging.Notification
                            {
                                Title = "Bài tập sắp hết hạn",
                                Body = $"Bài tập '{assignment.Title}' sẽ hết hạn vào lúc {assignment.Deadline}"
                            },
                            Tokens = tokens.ToList(),
                        };

                        BatchResponse response = await _firebaseMessaging.SendEachForMulticastAsync(outOfDateMessage);
                        if (response.FailureCount > 0)
                        {
                            var failedTokens = new List<string>();
                            for (int i = 0; i < response.Responses.Count; i++)
                            {
                                if (!response.Responses[i].IsSuccess)
                                {
                                    failedTokens.Add(tokens.ToList()[i]);
                                }
                            }
                            Console.WriteLine("Failed tokens: " + string.Join(", ", failedTokens));
                        }
                    }
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
