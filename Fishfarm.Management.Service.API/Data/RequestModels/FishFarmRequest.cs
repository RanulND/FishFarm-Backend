using System;
using Fishfarm.Management.Service.API.Data.Models;

namespace Fishfarm.Management.Service.API.Data.RequestModels;

public class FishFarmRequest
{
    public string Name { get; set; } = default!;
    public long CageCount { get; set; }
    public bool HasBarge { get; set; }
    public string Picture { get; set; } = default!;
    public CoordinateRequest Coordinate { get; set; } = default!;
}

