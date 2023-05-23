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
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<IPresetTaskItemRepository, PresetTaskItemRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProfileTypeRepository, ProfileTypeRepository>();
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            services.AddScoped<ITimesheetRepository, TimesheetRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
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
                    opt.UseSqlServer(ConnectionStringBuilder.BuildEnvCnnStr())
                        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Error)
            );
    }
}
