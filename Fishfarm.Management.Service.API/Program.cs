using Fishfarm.Management.Service.API.Data.Context;
using Microsoft.EntityFrameworkCore;
using Fishfarm.Management.Service.API.Services.Mappers;
using Fishfarm.Management.Service.API.Interfaces;
using Fishfarm.Management.Service.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var AllowedOrigins = "allowedOrigins";

builder.Services.AddCors(options => options.AddPolicy(name: "allowedOrigins", policy =>
{
    policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();

}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IFishFarmService, FishFarmService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IFileService, FileService>();


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

app.UseCors(AllowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

