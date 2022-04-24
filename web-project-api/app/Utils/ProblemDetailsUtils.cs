using Flunt.Notifications;
namespace web_project_api.app.Utils;

    public static class ProblemDetailsUtils
    {
        public static Dictionary<string, string[]> ConvertProblemDetails(this IReadOnlyCollection<Notification> notifications) {
            return notifications
                    .GroupBy(t => t.Key)
                    .ToDictionary(t => t.Key, t => t.Select(x => x.Message).ToArray());
        }
    }
