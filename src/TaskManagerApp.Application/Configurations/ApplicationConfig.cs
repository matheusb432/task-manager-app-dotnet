using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Services;

namespace TaskManagerApp.Application.Configurations
{
    public static class ApplicationConfig
    {
        public static void AddApplicationConfig(
            this IServiceCollection services,
            IConfiguration configuration,
            bool isEnv
        )
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddJWTAuth(configuration, isEnv);

            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGoalService, GoalService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ITaskItemService, TaskItemService>();
            services.AddScoped<ITimesheetService, TimesheetService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ISettingsService, SettingsService>();
        }
    }
}
