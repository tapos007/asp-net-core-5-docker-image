using System;
using DLL.EFCORE;
using DLL.EFCORE.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL
{
    public static class DLLDependency
    {

        public static void AllDLLDependency(this IServiceCollection services,IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));

            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            services.AddDbContext<ApplicationDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    .EnableSensitiveDataLogging() // <-- These two calls are optional but help
                    .EnableDetailedErrors()       // <-- with debugging (remove for production).
            );
            
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}