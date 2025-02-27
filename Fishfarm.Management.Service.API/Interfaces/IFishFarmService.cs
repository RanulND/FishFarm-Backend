﻿using System;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Data.ResponseModels;

namespace Fishfarm.Management.Service.API.Interfaces;

public interface IFishFarmService
{
    Task<IEnumerable<FishFarmResponse>> GetAllFishFarmsAsync();

    Task<FishFarmResponse> CreateFishFarmAsync(FishFarmRequest request);
}

