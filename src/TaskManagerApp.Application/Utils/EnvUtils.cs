namespace TaskManagerApp.Application.Utils
{
    public static class EnvUtils
    {
        public static string GetEnv(string key) =>
            Environment.GetEnvironmentVariable(key) ?? string.Empty;

        public static bool IsDockerInstance() => GetEnv("DOTNET_RUNNING_IN_CONTAINER") == "true";
    }
}
