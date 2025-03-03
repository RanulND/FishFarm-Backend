using System;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Interfaces;
using Fishfarm.Management.Service.API.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Fishfarm.Management.Service.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FishFarmController : ControllerBase
{
	private readonly IFishFarmService _fishFarmService;

	public FishFarmController(IFishFarmService fishFarmService)
	{
		_fishFarmService = fishFarmService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllFishFarms()
	{
		try
		{
			return Ok(await _fishFarmService.GetAllFishFarmsAsync());
		} catch (Exception e)
		{
			return BadRequest(e.Message);
		}
	}

	[HttpPost]
	public async Task<IActionResult> CreateFishFarm([FromBody] FishFarmRequest request)
	{
		try
		{
			return Ok(await _fishFarmService.CreateFishFarmAsync(request));
		} catch (Exception e)
		{
			return BadRequest(e.Message);
		}
	}

	[HttpPatch("{id}")]
	public async Task<IActionResult> UpdateFishFarm(long id, [FromBody] FishFarmRequest request)
	{
		try
		{
			return Ok(await _fishFarmService.UpdateFishFarmAsync(id,request));
		} catch (Exception e)
		{
            if (e is FishFarmNotFoundException)
            {
                return NotFound(e.Message);
            }
            return BadRequest(e.Message);
		}
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteFishFarm(long id)
	{
		try
		{
			await _fishFarmService.DeleteFishFarmAsync(id);
			return NoContent();
		}catch (Exception e)
		{
			if(e is FishFarmNotFoundException)
			{
				return NotFound(e.Message);
			}
			return BadRequest(e.Message);
		}
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetFishFarm(long id)
	{
		try
		{
			return Ok(await _fishFarmService.GetFishFarmAsync(id));
		}catch(Exception e)
		{
			return BadRequest(e.Message);
		}
	}

}

