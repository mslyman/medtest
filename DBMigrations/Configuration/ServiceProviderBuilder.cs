using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DBMigrations
{
    public static class ServiceProviderBuilder
    {
        public static IServiceProvider GetServiceProvider()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            bool fileExists = File.Exists(filePath);

            if (!fileExists)
                throw new Exception("File not found: " + filePath);

            var configuration = new ConfigurationBuilder()
                //.SetBasePath(env.ContentRootPath)
                .AddJsonFile(filePath, false, true)
                //.AddUserSecrets(typeof(Program).Assembly)
                .Build();
            var services = new ServiceCollection();
            services.Configure<AppSettings>(configuration.GetSection(typeof(AppSettings).FullName));

            var provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
