using autoFlexrentalBackend.Interfaces;
using autoFlexrentalBackend.Models;
using autoFlexrentalBackend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuraci�n CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policyBuilder =>
        {
            policyBuilder.WithOrigins("http://localhost:3000") // Direcci�n del frontend
                         .AllowAnyMethod()
                         .AllowAnyHeader();
        });
});

// Configuraci�n de la conexi�n a la base de datos
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AutoFlexRentalContext>(options =>
    options.UseSqlServer(conn, sqlOptions =>
        sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null) // Habilita reintentos autom�ticos
    )
);  // Se mantiene el contexto DB como Scoped (es lo correcto)

// Inyecci�n de dependencias
builder.Services.AddScoped<IAutoflexRentalService, AutoflexRentalService>();
builder.Services.AddScoped<IVehicleSearchService, VehicleSearchService>();

var app = builder.Build();

// Configuraci�n del pipeline de la aplicaci�n
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
