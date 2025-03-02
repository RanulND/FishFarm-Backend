using System;
using AutoMapper;
using Fishfarm.Management.Service.API.Data.Models;
using Fishfarm.Management.Service.API.Data.RequestModels;
using Fishfarm.Management.Service.API.Data.ResponseModels;

namespace Fishfarm.Management.Service.API.Services.Mappers;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<FishFarm, FishFarmResponse>()
			.ForMember(dest => dest.Coordinate, opt => opt.MapFrom(src => src.Coordinate));

		CreateMap<Coordinate, CoordinateResponse>();
		CreateMap<FishFarmRequest, FishFarm>();
		CreateMap<CoordinateRequest, Coordinate>();
		CreateMap<WorkerRequest, Worker>();
		CreateMap<Worker, WorkerResponse>()
			.ForMember(dest => dest.WorkerPosition, opt => opt.MapFrom(src => src.WorkerPosition.ToString()));
		CreateMap<FishFarmResponse, FishFarm>();
    }
}

