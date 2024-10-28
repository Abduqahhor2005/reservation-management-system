using EMS.Response;
using Microsoft.AspNetCore.Mvc;
using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Entities;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Response;
using ReservationManagementSystem.Service.Worker;

namespace ReservationManagementSystem.Controller;

[ApiController]
[Route("api/worker")]
public class WorkerController(IWorkerService workerService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetWorkers([FromQuery] WorkerFilter filter)
        => Ok(ApiResponse<PaginationResponse<IEnumerable<ReadWorker>>>.Success(null,
            workerService.GetAll(filter)));
    
    [HttpGet("{id:int}")]
    public IActionResult GetWorkerById(int id)
    {
        ReadWorker? res = workerService.GetById(id);
        return res != null
            ? Ok(ApiResponse<ReadWorker?>.Success(null, res))
            : NotFound(ApiResponse<ReadWorker?>.Fail(null, null));
    }
    
    [HttpPost]
    public IActionResult CreateWorker([FromBody] string fullName, int age, string email, string phoneNumber,
        TimeSpan startTime, TimeSpan endTime, string profession, double payment, Status status, 
        int locationId)
    {
        CreateWorker location = new CreateWorker(fullName,age,email,phoneNumber,startTime,endTime,profession,payment,
            status, locationId);
        bool res = workerService.Create(location);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : BadRequest(ApiResponse<bool>.Fail(null, res));
    }
    
    [HttpPut]
    public IActionResult UpdateWorker(UpdateWorker location)
    {
        bool res = workerService.Update(location);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteWorker(int id)
    {
        bool res = workerService.Delete(id);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
}