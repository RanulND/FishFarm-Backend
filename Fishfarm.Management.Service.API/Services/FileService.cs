using System;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Data.ResponseModels;
using Fishfarm.Management.Service.API.Interfaces;

namespace Fishfarm.Management.Service.API.Services;

public class FileService : IFileService
{
    private readonly IConfiguration _configuration;

    public FileService(IConfiguration configuration)
	{
        _configuration = configuration;
	}

    public async Task<FileResponse> CreateFileAsync(IFormFile file, string path)
    {
        var filePath = Path.Combine(_configuration["AssetPath"]!,path,file.FileName);

        using (var stream = File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }

        var fileResponse = new FileResponse()
        {
            Path = filePath
        };

        return fileResponse;
    }
}

