using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace DBMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ServiceProviderBuilder.GetServiceProvider();
            var appSettings = services.GetRequiredService<IOptions<AppSettings>>().Value;

            Console.WriteLine($"Connection string: {appSettings.ConnectionString}");
            Console.WriteLine($"Start migration (y/n)?");
            if (Console.ReadKey().KeyChar == 'y')
            {
                using var context = new MainDbContextFactory().CreateDbContext(appSettings.ConnectionString);
                context.Database.Migrate();
                Console.WriteLine();
                Console.WriteLine("Migrate ok");
                Console.WriteLine();
            }
        }
    }
}
