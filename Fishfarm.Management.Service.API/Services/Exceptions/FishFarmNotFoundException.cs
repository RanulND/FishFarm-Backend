using System;
namespace Fishfarm.Management.Service.API.Services.Exceptions;

public class FishFarmNotFoundException : Exception
{
	public FishFarmNotFoundException(string message) : base(message)
	{
        
	}
}

