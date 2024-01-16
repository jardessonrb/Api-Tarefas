using apitarefas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apitarefas.Data.Map;

public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
{
    public void Configure(EntityTypeBuilder<UsuarioModel> builder)
    {
        builder.HasKey(usuario => usuario.Id);
        builder.Property(usuario => usuario.Email).IsRequired().HasMaxLength(60);
        builder.Property(usuario => usuario.Nome).IsRequired().HasMaxLength(150);
    }
}