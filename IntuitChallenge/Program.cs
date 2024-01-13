using IntuitChallenge.Data;
using IntuitChallenge.Models;
using IntuitChallenge.Models.DTO;
using IntuitChallenge.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using IntuitChallenge;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// agrego AutoMapper
builder.Services.AddAutoMapper(typeof(MappingConfig));


// Acá registro la inyección de dependencias para el servicio de Db
builder.Services.AddScoped<IClienteService, ClienteService>();

// Conecto la base de datos al proyecto

builder.Services.AddDbContext<ClientesDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

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
