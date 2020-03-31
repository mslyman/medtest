using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBModel;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Data.Interfaces;
using Data.Services;

namespace WebApi2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }




        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped<ValidateModelAttribute>();

            string connectionString = Configuration.GetConnectionString("MainDbContext");
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<MainDbContext>(options => options.UseNpgsql(connectionString));

            //services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors();

            // https://docs.microsoft.com/ru-ru/aspnet/core/web-api/?view=aspnetcore-3.1
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true; // disable default validation response, use ValidateModelAttribute
            });

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // System.Text.Json serialization
                    options.JsonSerializerOptions.IgnoreNullValues = true; // No emit nullvalues
                    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic);
                });

            AddDependencies(services);
        }


        private static void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserQuery, UserQuery>();
            services.AddScoped<IUserCommand, UserCommand>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseApiException();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
