using Microsoft.EntityFrameworkCore;
using TesteTecnicoCodenApp.Models;

namespace TesteTecnicoCodenApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Orcamento> Orcamentos { get; set; }
    public DbSet<OrcamentoItem> OrcamentoItens { get; set; }
}
