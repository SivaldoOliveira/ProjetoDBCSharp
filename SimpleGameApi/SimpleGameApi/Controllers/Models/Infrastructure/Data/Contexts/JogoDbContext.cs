using Microsoft.EntityFrameworkCore;
using SimpleGameApi.Controllers.Models.Domain.Entities;


namespace SimpleGameApi.Controllers.Models.Infrastructure.Data.Contexts;

public class JogoDbContext : DbContext
{
    public JogoDbContext(DbContextOptions<JogoDbContext> options)
        :base(options)
    {

    }

    public DbSet<Jogo> Jogos { get; set; }

    public DbSet<Estoque> Estoque { get; set; }
}
