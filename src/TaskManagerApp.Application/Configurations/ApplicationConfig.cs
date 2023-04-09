using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services;

namespace TaskManagerApp.Application.Configurations
{
    public static class ApplicationConfig
    {
        public static void AddApplicationDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGoalService, GoalService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ITaskItemService, TaskItemService>();
            services.AddScoped<ITimesheetService, TimesheetService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}