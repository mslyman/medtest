using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DBModel;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DBMigrations
{
    public class MainDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        public MainDbContext CreateDbContext(params string[] args)
        {
            var services = ServiceProviderBuilder.GetServiceProvider();
            var appSettings = services.GetRequiredService<IOptions<AppSettings>>().Value;
            string connectionString = appSettings.ConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();

            string assemblyName = typeof(Program).Assembly.GetName().Name;
            optionsBuilder.UseNpgsql(connectionString, b => b.MigrationsAssembly(assemblyName));
            return new MainDbContext(optionsBuilder.Options);
        }

    }
}
