namespace TaskManagerApp.API.Configurations
{
    public static class CacheConfig
    {
        public const int KB_BYTES = 1024;
        public static void AddCacheConfiguration(this IServiceCollection services)
        {
            services.AddResponseCaching(options =>
            {
                options.MaximumBodySize = 10 * KB_BYTES;
                options.SizeLimit = 100 * KB_BYTES;
            });
        }
    }
}
