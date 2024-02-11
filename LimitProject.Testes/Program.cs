using LimitProject.Testes.Extensions;
using LimitProject.Testes.Main;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            var serviceCollection = ConfigureServices();
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            var eventService = serviceProvider.GetRequiredService<AppMainTest>();
            eventService.Execute();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    static IServiceCollection ConfigureServices()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddDependencies();
        return serviceCollection;
    }

}