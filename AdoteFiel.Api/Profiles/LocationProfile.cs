using AdoteFiel.Api.Data.Dto;
using AdoteFiel.Api.Models;
using AutoMapper;

namespace AdoteFiel.Api.Profiles;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<Location, LocationDto>();
    }
}
