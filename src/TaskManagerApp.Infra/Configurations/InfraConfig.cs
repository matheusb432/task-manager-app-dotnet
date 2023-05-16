using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagerApp.Infra.Extensions;
using TaskManagerApp.Infra.Interfaces;
using TaskManagerApp.Infra.Repositories;
using TaskManagerApp.Infra.Utils;

namespace TaskManagerApp.Infra.Configurations
{
    public static class InfraConfig
    {
        public static void AddInfraConfiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            bool isEnv = false
        )
        {
            if (isEnv)
                services.AddEnvDatabase();
            else
                services.AddDatabase(configuration);

            services.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IGoalRepository, GoalRepository>();
            services.AddTransient<IPresetTaskItemRepository, PresetTaskItemRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<IProfileTypeRepository, ProfileTypeRepository>();
            services.AddTransient<ITaskItemRepository, TaskItemRepository>();
            services.AddTransient<ITimesheetRepository, TimesheetRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        private static void AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration
        ) =>
            services.AddDbContext<TaskManagerContext>(
                opt =>
                    opt.UseSqlServer(
                            configuration.GetConnectionString(InfraUtils.DefaultConnectionName)
                        )
                        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Error)
            );

        private static void AddEnvDatabase(this IServiceCollection services) =>
            services.AddDbContext<TaskManagerContext>(
                opt =>
                    opt.UseSqlServer(ConnectionStringBuilder.BuildEnvCnnStr("TaskManagerAppDB"))
                        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Error)
            );
    }
}
