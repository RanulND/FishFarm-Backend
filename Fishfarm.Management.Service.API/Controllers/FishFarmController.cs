using System;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Interfaces;
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
		}catch (Exception e)
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
		}catch (Exception e)
		{
			return BadRequest(e.Message);
		}
	}
	
}

