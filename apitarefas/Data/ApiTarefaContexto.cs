using apitarefas.Data.Map;
using apitarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace apitarefas.Data;

public class ApiTarefaContexto : DbContext
{
    public ApiTarefaContexto(DbContextOptions<ApiTarefaContexto> options) : base(options) { }
    
    public DbSet<UsuarioModel> Usuarios { get; set; }
    
    public DbSet<TarefaModel> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new TarefaMap());
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<TarefaModel>()
            .ToTable("tb_tarefas");

        modelBuilder.Entity<UsuarioModel>()
            .ToTable("tb_usuarios");
    }
}