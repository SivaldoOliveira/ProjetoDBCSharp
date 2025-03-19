
namespace SimpleGameApi.Controllers.Models.Domain.Configuration;

public static class Startup
{
    public static void Configure(IConfiguration configuration, IServiceCollection services)
    {
        ConfigureDatabase(configuration, services);
        ConfigueDependencies(services);
    }

  

    private static void ConfigureDatabase(IConfiguration configuration, IServiceCollection services)
    {
        var connStr = configuration.GetConnectionString("JogosDb") ??
              throw new ArgumentException("Connectionm String não localizada");

        //incluir configuração para o contexto do meu EF Core
    }

    private static void ConfigueDependencies(IServiceCollection services)
    {
        ConfigureRepositories(services);
        ConfigureServices(services);
    }
       

    private static void ConfigureRepositories(IServiceCollection services)
    {
        // Incluir dependencias de repositorios
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Incluir dependencias de servicos
    }
}
