using System;
namespace Fishfarm.Management.Service.API.Services.Exceptions
{
	public class WorkerNotFoundException : Exception
	{
		public WorkerNotFoundException(string message) : base(message)
		{
		}
	}
}

