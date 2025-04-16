using Microsoft.EntityFrameworkCore;
using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Contracts.Services;
using SimpleGameApi.Models.Domain.Entities;
using SimpleGameApi.Models.Infrastructure.Data.Contexts;
using SimpleGameApi.Models.Infrastructure.Data.Repositories;
using SimpleGameApi.Models.Services;

namespace SimpleGameApi.Models.Configuration;

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

        services.AddDbContext<JogoDbContext>(options =>
        options.UseSqlServer(connStr));

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
        services.AddScoped<IJogoRepository, JogoRepository>();
        services.AddScoped<IEstoqueRepository, EstoqueRepository>();
        services.AddScoped<IVendaRepository, VendaRepository > ();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Incluir dependencias de servicos

        services.AddScoped<IJogoService, JogoService>();
        services.AddScoped<IEstoqueService, EstoqueService>();
        services.AddScoped<IVendaService, VendaService>();
    }
}
