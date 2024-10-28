using EMS.Response;
using Microsoft.AspNetCore.Mvc;
using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Response;
using ReservationManagementSystem.Service.Client;

namespace ReservationManagementSystem.Controller;

[ApiController]
[Route("api/client")]
public class ClientController(IClientService clientService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetClients([FromQuery] ClientFilter filter)
        => Ok(ApiResponse<PaginationResponse<IEnumerable<ReadClient>>>.Success(null,
            clientService.GetAll(filter)));
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetClientById(int id)
    {
        ReadClient? res = clientService.GetById(id);
        return res != null
            ? Ok(ApiResponse<ReadClient?>.Success(null, res))
            : NotFound(ApiResponse<ReadClient?>.Fail(null, null));
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult CreateClient([FromBody] string fullName, int age, string email, string phoneNumber,
        TimeSpan startTime, TimeSpan endTime, int locationId)
    {
        CreateClient location = new CreateClient(fullName,age,email,phoneNumber,startTime,endTime, locationId);
        bool res = clientService.Create(location);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : BadRequest(ApiResponse<bool>.Fail(null, res));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateClient(UpdateClient location)
    {
        bool res = clientService.Update(location);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteClient(int id)
    {
        bool res = clientService.Delete(id);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
}