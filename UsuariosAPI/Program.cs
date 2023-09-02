using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//armazenando a Connection String na variavel
var connectionString = builder.Configuration.GetConnectionString("UsuarioConnection");

//Adicionando DB context para usar o MySql
builder.Services.AddDbContext<UsuarioDbContext>(
    opts =>
    {
        opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
