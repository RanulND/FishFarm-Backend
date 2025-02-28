using System;
using AutoMapper;
using Fishfarm.Management.Service.API.Data.Context;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Data.ResponseModels;
using Fishfarm.Management.Service.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fishfarm.Management.Service.API.Services
{
	public class WorkerService : IWorkerService
	{
		private readonly IMapper _mapper;

		public WorkerService(IMapper mapper)
		{
			_mapper = mapper;
		}

        public Task<WorkerResponse> CreateWorkerAsync(WorkerRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWorkerAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkerResponse>> GetAllWorkersForFishFarmAsync()
        {
            using var dbContext = new FishFarmDbContext();

            var res = await dbContext.Workers.ToListAsync();

            return _mapper.Map<IEnumerable<WorkerResponse>>(res);
        }

        public Task<WorkerResponse> UpdateWorkerAsync(long id, WorkerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

