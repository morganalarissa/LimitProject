using LimitProject.Infrastructure.Repositories;
using LimitProject.Services.Service;

namespace LimitProject.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) 
        {
            RegisterDependencies(services);
            services.AddControllers();
            
        }

        private void RegisterDependencies(IServiceCollection services)
        {
            services.AddSingleton<IClientRepository, ClientRepository>();

            services.AddScoped<ClientService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { });
        }
    }
}
