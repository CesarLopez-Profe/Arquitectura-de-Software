using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PrestamosVehiculos.Infrastructure.Persistence;
using PrestamosVehiculos.Infrastructure.Repositories;
using PrestamosVehiculos.Domain.Interfaces;
using PrestamosVehiculos.Domain.Services;
using MediatR;
using System.Reflection;
using PrestamosVehiculos.Infrastructure.Cache;
using PrestamosVehiculos.Infrastructure;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Cfg builder
//var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos SQL Server
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(connectionString)); //se cambia el uso de una BD SQLExpress

//Se usa una base de datos en memoria
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase("PrestamosDB")); 

// Configurar los repositorios e inyectarlos en la aplicación
builder.Services.AddScoped<IPrestamoRepository, PrestamoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

// Registrar servicios de dominio
builder.Services.AddScoped<EvaluadorCreditoService>();
builder.Services.AddScoped<CalculoCuotasService>();
builder.Services.AddScoped<ValidacionPagoService>();

// habilita el servicio de memoria
builder.Services.AddMemoryCache(); 
builder.Services.AddScoped<ICacheService, MemoryCacheService>();

//Registro del servicio UnitofWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registrar MediatR para manejar CQRS
//version vieja builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

// Habilitar Swagger para documentar la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Préstamos", Version = "v1" });
});


//var app = builder.Build();

builder.Services.AddAuthorization();
var app = builder.Build();

// Configurar Swagger en modo desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Préstamos v1"));
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();

/*
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();
*/

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
