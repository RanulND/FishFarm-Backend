using System;
using Fishfarm.Management.Service.API.Data.Models;

namespace Fishfarm.Management.Service.API.Data.ResponseModels;

public class WorkerResponse
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime DOB { get; set; }
    public string Email { get; set; } = default!;
    public DateTime CertifiedUntil { get; set; }
    public string WorkerPosition { get; set; } = default!;
    public string? Picture { get; set; }
}

