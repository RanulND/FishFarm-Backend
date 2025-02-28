using System;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Data.ResponseModels;

namespace Fishfarm.Management.Service.API.Interfaces;

public interface IWorkerService
{
    Task<IEnumerable<WorkerResponse>> GetAllWorkersForFishFarmAsync();

    Task<WorkerResponse> CreateWorkerAsync(WorkerRequest request);

    Task<WorkerResponse> UpdateWorkerAsync(long id, WorkerRequest request);

    Task DeleteWorkerAsync(long id);
}

