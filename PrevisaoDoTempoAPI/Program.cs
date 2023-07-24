using Microsoft.EntityFrameworkCore;
using PrevisaoDoTempoAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(obj => obj.UseMySql(builder.Configuration.GetConnectionString("conexaoMySQL")
    , ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("conexaoMySQL"))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
