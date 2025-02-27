using System;
using AutoMapper;
using Fishfarm.Management.Service.API.Data.Context;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Data.ResponseModels;
using Fishfarm.Management.Service.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fishfarm.Management.Service.API.Services;

public class FishFarmService : IFishFarmService
{
    private readonly IMapper _mapper;

    public FishFarmService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<FishFarmResponse>> GetAllFishFarmsAsync()
    {
        using var dbContext = new FishFarmDbContext();

        var res = await dbContext.FishFarms.ToListAsync();

        return _mapper.Map<IEnumerable<FishFarmResponse>>(res);
    }

    public async Task<FishFarmResponse> CreateFishFarmAsync(FishFarmRequest request)
    {
        using var dbContext = new FishFarmDbContext();

        var res = await dbContext.AddAsync(request);
        await dbContext.SaveChangesAsync();

        return _mapper.Map<FishFarmResponse>(res);
    }
}

