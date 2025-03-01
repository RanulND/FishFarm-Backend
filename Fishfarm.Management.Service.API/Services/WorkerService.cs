using System;
using AutoMapper;
using Azure.Core;
using Fishfarm.Management.Service.API.Data.Context;
using Fishfarm.Management.Service.API.Data.Models;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Data.ResponseModels;
using Fishfarm.Management.Service.API.Interfaces;
using Fishfarm.Management.Service.API.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Fishfarm.Management.Service.API.Services
{
	public class WorkerService : IWorkerService
	{
		private readonly IMapper _mapper;
        private IFishFarmService _fishFarmService;

		public WorkerService(IMapper mapper, IFishFarmService fishFarmService)
		{
			_mapper = mapper;
            _fishFarmService = fishFarmService;
		}

        public async Task<WorkerResponse> CreateWorkerAsync(WorkerRequest request)
        {
            using var dbContext = new FishFarmDbContext();

            var worker = await dbContext.Workers.Where(_ => _.FishFarm.Id == request.FishFarmId).FirstOrDefaultAsync(_ => _.Email == request.Email);

            if (worker is not null)
            {
                throw new WorkerExistException("Worker already exists in the organization");
            }

            var fishFarm = _fishFarmService.GetFishFarmAsync(request.FishFarmId);

            var newWorker = new Worker()
            {
                Name = request.Name,
                CertifiedUntil = request.CertifiedUntil,
                DOB = request.DOB,
                Email = request.Email,
                Picture = request.Picture,
                WorkerPosition = request.WorkerPosition,
                FishFarm = _mapper.Map<FishFarm>(fishFarm)
            };

            var res = await dbContext.Workers.AddAsync(newWorker);
            await dbContext.SaveChangesAsync();

            return _mapper.Map<WorkerResponse>(res.Entity);
        }

        public async Task DeleteWorkerAsync(long id,long fishFarmId)
        {
            using var dbContext = new FishFarmDbContext();
            var worker = await dbContext.Workers.Where(_ => _.FishFarm.Id == fishFarmId).FirstOrDefaultAsync(_ => _.Id == id) ?? throw new WorkerNotFoundException("Worker not found");
            dbContext.Workers.Remove(worker);
            await dbContext.SaveChangesAsync();

        }
        public async Task<IEnumerable<WorkerResponse>> GetAllWorkersForFishFarmAsync()
        {
            using var dbContext = new FishFarmDbContext();

            var res = await dbContext.Workers.ToListAsync();

            return _mapper.Map<IEnumerable<WorkerResponse>>(res);
        }

        public async Task<WorkerResponse> UpdateWorkerAsync(long id, WorkerRequest request)
        {
            using var dbContext = new FishFarmDbContext();

            var worker = await dbContext.Workers.Where(_ => _.FishFarm.Id == request.FishFarmId).FirstOrDefaultAsync(_ => _.Id == id) ?? throw new WorkerNotFoundException("Worker not found");

            var fishFarm = _fishFarmService.GetFishFarmAsync(request.FishFarmId);

            var newWorker = new Worker();
            newWorker.Id = id;
            newWorker.CertifiedUntil = request.CertifiedUntil;
            newWorker.DOB = request.DOB;
            newWorker.Email = request.Email;
            newWorker.Name = request.Name;
            newWorker.Picture = request.Picture;
            newWorker.WorkerPosition = request.WorkerPosition;
            newWorker.FishFarm = _mapper.Map<FishFarm>(fishFarm);

            var res = dbContext.Workers.Update(newWorker);
            await dbContext.SaveChangesAsync();

            return _mapper.Map<WorkerResponse>(res.Entity);
        }
    }
}

