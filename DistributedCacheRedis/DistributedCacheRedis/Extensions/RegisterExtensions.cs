namespace DistributedCacheRedis.Extensions
{
    public static class RegisterExtensions
    {
        public static void RegisterRedis(this IServiceCollection services)
        {

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";


            });

        }
    }
}
