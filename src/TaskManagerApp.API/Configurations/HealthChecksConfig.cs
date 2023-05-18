using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using TaskManagerApp.Application.ViewModels;

namespace TaskManagerApp.API.Configurations
{
    public static class HealthChecksConfig
    {
        public static void UseHealthChecksConfig(this WebApplication app)
        {
            app.UseHealthChecks(
                "/health",
                new HealthCheckOptions
                {
                    ResponseWriter = async (context, report) =>
                    {
                        context.Response.ContentType = "application/json";
                        var response = new HealthCheckResponse
                        {
                            Status = report.Status.ToString(),
                            HealthChecks = report.Entries.Select(
                                x =>
                                    new IndividualHealthCheckResponse
                                    {
                                        Component = x.Key,
                                        Status = x.Value.Status.ToString(),
                                        Description = x.Value.Description ?? string.Empty
                                    }
                            ),
                            HealthCheckDuration = report.TotalDuration
                        };
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    }
                }
            );
        }
    }
}
