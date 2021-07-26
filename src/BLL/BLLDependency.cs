using BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class BLLDependency
    {
        public static void AllBLLDependency(this IServiceCollection services,IConfiguration configuration)
        {
            
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["RedisSetup:MyRedisConStr"];
                options.InstanceName = "RedisSetup:InstanceName";
            });
            
            
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IApplicationCashingService, ApplicationCashingService>();
        }
    }
}