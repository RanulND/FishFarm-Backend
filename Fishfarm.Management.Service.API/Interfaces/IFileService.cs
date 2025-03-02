using System;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Data.ResponseModels;

namespace Fishfarm.Management.Service.API.Interfaces;

public interface IFileService
{
	Task<FileResponse> CreateFileAsync(IFormFile file, string path);
}

