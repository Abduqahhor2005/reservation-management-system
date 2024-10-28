using EMS.Response;
using Microsoft.AspNetCore.Mvc;
using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Response;
using ReservationManagementSystem.Service.Location;

namespace ReservationManagementSystem.Controller;

[ApiController]
[Route("api/location")]
public class LocationController(ILocationService locationService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetLocations([FromQuery] LocationFilter filter)
        => Ok(ApiResponse<PaginationResponse<IEnumerable<ReadLocation>>>.Success(null,
            locationService.GetAll(filter)));
    
    [HttpGet("{id:int}")]
    public IActionResult GetLocationById(int id)
    {
        ReadLocation? res = locationService.GetById(id);
        return res != null
            ? Ok(ApiResponse<ReadLocation?>.Success(null, res))
            : NotFound(ApiResponse<ReadLocation?>.Fail(null, null));
    }
    
    [HttpPost]
    public IActionResult CreateLocation([FromBody] string country, string city, string region, string address)
    {
        CreateLocation location = new CreateLocation(country,city,region,address);
        bool res = locationService.Create(location);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : BadRequest(ApiResponse<bool>.Fail(null, res));
    }
    
    [HttpPut]
    public IActionResult UpdateLocation(UpdateLocation location)
    {
        bool res = locationService.Update(location);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteLocation(int id)
    {
        bool res = locationService.Delete(id);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
}