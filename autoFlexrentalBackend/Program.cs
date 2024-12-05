using autoFlexrentalBackend.Interfaces;
using autoFlexrentalBackend.Models;
using autoFlexrentalBackend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policyBuilder =>
        {
            policyBuilder.WithOrigins("http://localhost:3000") // Dirección del frontend
                         .AllowAnyMethod()
                         .AllowAnyHeader();
        });
});

// Configuración de la conexión a la base de datos
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AutoFlexRentalContext>(options =>
    options.UseSqlServer(conn, sqlOptions =>
        sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null) // Habilita reintentos automáticos
    )
);  // Se mantiene el contexto DB como Scoped (es lo correcto)

// Inyección de dependencias
builder.Services.AddScoped<IAutoflexRentalService, AutoflexRentalService>();
builder.Services.AddScoped<IVehicleSearchService, VehicleSearchService>();

var app = builder.Build();

// Configuración del pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
