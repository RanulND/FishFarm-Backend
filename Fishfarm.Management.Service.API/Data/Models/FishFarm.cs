using System;
namespace Fishfarm.Management.Service.API.Data.Models;

public class FishFarm
{
	public long Id { get; set; }
	public string Name { get; set; } = default!;
	public long CageCount { get; set; }
	public bool Hasbarge { get; set; }
	public string Picture { get; set; } = default!;
	public Coordinate Coordinate { get; set; } = default!;
	public IEnumerable<Worker> Workers = new List<Worker>();

}

public class Coordinate
{
	public long Id { get; set; }
	public double X { get; set; }
	public double Y { get; set; }
}

