﻿using TaskManagerApp.Infra.Utils;

namespace TaskManagerApp.Infra.Extensions
{
    public static class ConnectionStringBuilder
    {
        public static string BuildEnvCnnStr(string? databaseName = "TmaDB")
        {
            var user = InfraUtils.GetEnv("DB_USERNAME");
            var host = InfraUtils.GetEnv("DB_HOST");
            var name = InfraUtils.GetEnv("DB_NAME") ?? databaseName;
            var password = InfraUtils.GetEnv("DB_PASSWORD");

            string cnnStr =
                $"Server={host}; Database={name}; User ID={user}; TrustServerCertificate=True;Password={password}";

            return cnnStr;
        }
    }
}
