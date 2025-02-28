using System;
using Fishfarm.Management.Service.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fishfarm.Management.Service.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkerController
{
	private readonly IWorkerService _workerService;

	public WorkerController(IWorkerService workerService)
	{
		_workerService = workerService;
	}
}

