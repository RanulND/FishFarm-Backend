using System;
using Fishfarm.Management.Service.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Fishfarm.Management.Service.API.Data.Context;

public class FishFarmDbContext : DbContext
{
    public FishFarmDbContext() { }

    public FishFarmDbContext(DbContextOptions<FishFarmDbContext> options) : base(options) { }

	public virtual DbSet<FishFarm> FishFarms { get; set; }
	public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("fishfarm_db_connection_string"));
    }
}
	

