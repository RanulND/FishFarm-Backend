using System;
using Fishfarm.Management.Service.API.Data.Models;

namespace Fishfarm.Management.Service.API.Data.RequestModels;

public class WorkerRequest
{
    public string Name { get; set; } = default!;
    public DateTime DOB { get; set; }
    public string Email { get; set; } = default!;
    public DateTime CertifiedUntil { get; set; }
    public WorkerPosition WorkerPosition { get; set; }
    public string? Picture { get; set; }
    public long FishFarmId { get; set; } = default!;
}

