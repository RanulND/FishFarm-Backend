using System;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Data.ResponseModels;

namespace Fishfarm.Management.Service.API.Interfaces;

public interface IFishFarmService
{
    Task<IEnumerable<FishFarmResponse>> GetAllFishFarmsAsync();

    Task<FishFarmResponse> CreateFishFarmAsync(FishFarmRequest request);

    Task<FishFarmResponse> UpdateFishFarmAsync(long id, FishFarmRequest request);

    Task DeleteFishFarmAsync(long id);

    Task<FishFarmResponse> GetFishFarmAsync(long id);
}

