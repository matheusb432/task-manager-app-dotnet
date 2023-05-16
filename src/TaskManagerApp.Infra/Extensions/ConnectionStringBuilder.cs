using TaskManagerApp.Infra.Utils;

namespace TaskManagerApp.Infra.Extensions
{
    public static class ConnectionStringBuilder
    {
        public static string BuildEnvCnnStr(string? databaseName = "TaskManagerAppDB")
        {
            var user = InfraUtils.GetEnv("DB_USERNAME");
            var url = InfraUtils.GetEnv("DB_URL");
            var name = InfraUtils.GetEnv("DB_NAME") ?? databaseName;
            var password = InfraUtils.GetEnv("DB_PASSWORD");

            return $"Data Source={url}; Database={name}; User ID={user}; Password={password}";
        }
    }
}
