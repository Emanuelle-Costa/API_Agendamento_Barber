using Microsoft.EntityFrameworkCore;
using BarberShop.Data;
using BarberShop.Models;
using BarberShop.Models.Contratos;
using BarberShop.Data.Contratos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conexao = builder.Services.AddDbContext<ContextoBanco>(option => option.UseMySql(
    builder.Configuration.GetConnectionString("Conexao"),
    ServerVersion.Parse("8.0.31")
    )
);


builder.Services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

builder.Services.AddScoped<IProfissionalModel, ProfissionalModel>();
builder.Services.AddScoped<IGeralPersistencia, GeralPersistencia>();
builder.Services.AddScoped<IProfissionalPersistencia, ProfissionalPersistencia>();


builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
