using Fishfarm.Management.Service.API.Data.Context;
using Microsoft.EntityFrameworkCore;
using Fishfarm.Management.Service.API.Services.Mappers;
using Fishfarm.Management.Service.API.Interfaces;
using Fishfarm.Management.Service.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IFishFarmService, FishFarmService>();

var connectionString = builder.Configuration.GetConnectionString("fishfarm_db")!;
builder.Services.AddDbContext<FishFarmDbContext>(_ => _.UseSqlServer(connectionString));
Environment.SetEnvironmentVariable("fishfarm_db_connection_string", connectionString);

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

