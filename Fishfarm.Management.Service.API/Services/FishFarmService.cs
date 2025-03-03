using System;
using AutoMapper;
using Fishfarm.Management.Service.API.Data.Context;
using Fishfarm.Management.Service.API.Data.Models;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Data.ResponseModels;
using Fishfarm.Management.Service.API.Interfaces;
using Fishfarm.Management.Service.API.Services.Exceptions;
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

        var res = await dbContext.FishFarms.Include(_ => _.Coordinate).ToListAsync();

        return _mapper.Map<IEnumerable<FishFarmResponse>>(res);
    }

    public async Task<FishFarmResponse> CreateFishFarmAsync(FishFarmRequest request)
    {
        using var dbContext = new FishFarmDbContext();

        var fishFarm = _mapper.Map<FishFarm>(request);
        var res = await dbContext.FishFarms.AddAsync(fishFarm);
        await dbContext.SaveChangesAsync();

        return _mapper.Map<FishFarmResponse>(res.Entity);
    }

    public async Task<FishFarmResponse> UpdateFishFarmAsync(long id, FishFarmRequest request)
    {
        using var dbContext = new FishFarmDbContext();

        var fishFarm = await dbContext.FishFarms.FirstOrDefaultAsync(_ => id == _.Id) ?? throw new FishFarmNotFoundException("Fish farm not found");

        fishFarm.Name = request.Name;
        fishFarm.CageCount = request.CageCount;
        fishFarm.Coordinate = _mapper.Map<Coordinate>(request.Coordinate);
        fishFarm.HasBarge = request.HasBarge;
        fishFarm.Picture = request.Picture;
        
        var res = dbContext.FishFarms.Update(fishFarm);
        await dbContext.SaveChangesAsync();

        return _mapper.Map<FishFarmResponse>(res.Entity);
    }

    public async Task DeleteFishFarmAsync(long id)
    {
        using var dbContext = new FishFarmDbContext();

        var fishFarm = await dbContext.FishFarms.FirstOrDefaultAsync(_ => _.Id == id) ?? throw new FishFarmNotFoundException("Fish farm not found");
        dbContext.FishFarms.Remove(fishFarm);
        await dbContext.SaveChangesAsync();
    }

    public async Task<FishFarmResponse> GetFishFarmAsync(long id)
    {
        using var dbContext = new FishFarmDbContext();

        var fishFarm = await dbContext.FishFarms.Include(_ => _.Coordinate).FirstOrDefaultAsync(_ => _.Id == id) ?? throw new FishFarmNotFoundException("Fish farm not found");

        return _mapper.Map<FishFarmResponse>(fishFarm);
    }


}

