namespace TaskManagerApp.Infra.Utils
{
    public static class InfraUtils
    {
        public static readonly string DefaultConnectionName = "TaskManagerAppConnection";
        public static readonly string DefaultConnection = "Server=.\\SQLEXPRESS;Database=TaskManagerAppDB;Trusted_Connection=True;";

        public static string GetEnv(string key)
            => Environment.GetEnvironmentVariable(key) ?? string.Empty;
    }
}