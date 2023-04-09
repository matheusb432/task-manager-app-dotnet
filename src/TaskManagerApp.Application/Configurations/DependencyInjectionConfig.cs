using System.Reflection;
using TaskManagerApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManagerApp.Application.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddApplicationDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
