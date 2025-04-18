﻿using Microsoft.EntityFrameworkCore;
using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Infrastructure.Data.Contexts;

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
        services.AddScoped<IJogoRepository, IJogoRepository>();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Incluir dependencias de servicos
    }
}
