using System;
namespace Fishfarm.Management.Service.API.Data.RequestModels;

public class FileRequest
{
	public string? Path { get; set; }
	public IFormFile File { get; set; } = default!;
	public bool IsFarm { get; set; }
}

