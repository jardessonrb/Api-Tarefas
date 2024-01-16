using apitarefas.Data;
using apitarefas.Repositories.Usuario.Impl;
using apitarefas.services;
using Microsoft.EntityFrameworkCore;
using UsuarioRepository = apitarefas.Repositories.Usuario.UsuarioRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

//Adicionar para a aplicação conhecer os controllers implementados
builder.Services.AddControllers();

//Adicionar configuração para conexão com o banco de dados
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ApiTarefaContexto>(
        option => option
            .UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
        );

builder.Services.AddScoped<UsuarioRepository, UsuarioRepositoryImpl>();
builder.Services.AddScoped<UsuarioService>();


var app = builder.Build();

app.UseCors("AllowAny");
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();