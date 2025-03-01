using System;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Interfaces;
using Fishfarm.Management.Service.API.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Fishfarm.Management.Service.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkerController : ControllerBase
{
	private readonly IWorkerService _workerService;

	public WorkerController(IWorkerService workerService)
	{
		_workerService = workerService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllWorkersForFishFarm()
	{
		try
		{
			return Ok(await _workerService.GetAllWorkersForFishFarmAsync());
		} catch(Exception e)
		{
			return BadRequest(e.Message);
		}
	}

	[HttpPost]
	public async Task<IActionResult> CreateWorker([FromBody] WorkerRequest request)
	{
		try
		{
			return Ok(await _workerService.CreateWorkerAsync(request));
		}catch (Exception e)
		{
			return BadRequest(e.Message);
		}
	}

	[HttpPatch("{id}")]
	public async Task<IActionResult> UpdateWorker(long id, WorkerRequest request)
	{
		try
		{
			return Ok(await _workerService.UpdateWorkerAsync(id, request));
		}catch(Exception e)
		{
			if(e is WorkerNotFoundException)
			{
				return NotFound(e.Message);
			}

			return BadRequest(e.Message);
		}
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteWorker(long id, long fishFarmId)
	{
		try
		{
			await _workerService.DeleteWorkerAsync(id, fishFarmId);
            return NoContent();
		}catch (Exception e)
		{
			if(e is WorkerNotFoundException)
			{
				return NotFound(e.Message);
			}
			return BadRequest(e.Message);

		}
	}

}