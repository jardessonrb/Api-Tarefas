using apitarefas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apitarefas.Data.Map;

public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
{
    public void Configure(EntityTypeBuilder<TarefaModel> builder)
    {
        builder.HasKey(tarefa => tarefa.Id);
        builder.Property(tarefa => tarefa.Nome).IsRequired().HasMaxLength(150);
        builder.Property(tarefa => tarefa.Descricao).HasMaxLength(1000);
        builder.Property(tarefa => tarefa.Status).IsRequired();
        builder.Property(tarefa => tarefa.UsuarioId);
        
        //Define uma ligação de 1 - N
        builder.HasOne<UsuarioModel>(tarefa => tarefa.Usuario);
    }
}