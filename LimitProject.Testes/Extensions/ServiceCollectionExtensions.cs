using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LimitProject.Infrastructure.Repositories;
using LimitProject.Services.Service;
using LimitProject.Testes.Main;
using LimitProject.Testes.Repositories;
using LimitProject.Testes.Services;

namespace LimitProject.Testes.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            IConfiguration configuration = GetConfiguration();
            services.AddSingleton<IConfiguration>(configuration);
            RegisterDependencies(services);
            return services;
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<AppMainTest>();

            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<ClientService>();

            services.AddScoped<RepositoryTest>();

            services.AddScoped<ServiceTest>();

        }
        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            return configuration;
        }
    }
}
