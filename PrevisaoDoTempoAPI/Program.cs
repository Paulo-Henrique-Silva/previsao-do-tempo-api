using Microsoft.EntityFrameworkCore;
using PrevisaoDoTempoAPI.Data;
using PrevisaoDoTempoAPI.Interfaces;
using PrevisaoDoTempoAPI.Repositories;
using PrevisaoDoTempoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(obj => obj.UseMySql(builder.Configuration.GetConnectionString("conexaoMySQL")
    , ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("conexaoMySQL"))));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IChaveRepository, ChaveRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddScoped<IViaCEPRepository, ViaCEPRepository>();
builder.Services.AddScoped<ICPTECRepository, CPTECRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPrevisoesConsultasService, PrevisoesConsultasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
