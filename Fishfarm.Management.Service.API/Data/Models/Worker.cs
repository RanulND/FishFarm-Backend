using System;
namespace Fishfarm.Management.Service.API.Data.Models
{
	public class Worker
	{
		public long Id { get; set; }
		public string Name { get; set; } = default!;
		public DateTime DOB { get; set; }
		public string Email { get; set; } = default!;
		public DateTime CertifiedUntil { get; set; }
		public WorkerPosition WorkerPosition { get; set; }
		public string? Picture { get; set; }
		public FishFarm Fishfarm { get; set; } = default!;
	}
}

