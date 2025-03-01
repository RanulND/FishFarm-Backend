using System;
namespace Fishfarm.Management.Service.API.Services.Exceptions
{
	public class WorkerExistException : Exception
	{
		public WorkerExistException(string Message) : base(Message)
		{
		}
	}
}

