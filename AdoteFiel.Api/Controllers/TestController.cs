using AdoteFiel.Api.Data.Dto;
using AdoteFiel.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdoteFiel.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class TestController : ControllerBase
{
    private readonly LocationApiService _locationApiService;
    private readonly IMapper _mapper;

    public TestController(
        LocationApiService locationApiService, 
        IMapper mapper)
    {
        _locationApiService = locationApiService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<LocationDto> GetLocationAsync(string code)
    {
        var result = await _locationApiService.GetLocationByCepAsync(code)!;
        return _mapper.Map<LocationDto>(result);
    }
}
