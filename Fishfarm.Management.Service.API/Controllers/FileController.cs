using System;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fishfarm.Management.Service.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
	private readonly IFileService _fileService;

	public FileController(IFileService fileService)
	{
		_fileService = fileService;
	}

	[HttpPost("farm")]
	public async Task<IActionResult> CreateFileForFarm(IFormFile file)
	{
		var path = "FishFarm";
		try
		{
			return Ok(await _fileService.CreateFileAsync(file,path));
		}catch (Exception e)
		{
			return BadRequest(e.Message);
		}
	}

    [HttpPost("worker")]
    public async Task<IActionResult> CreateFileForWorker(IFormFile file)
    {
        var path = "Worker";
        try
        {
            return Ok(await _fileService.CreateFileAsync(file, path));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

