using EMS.Response;
using Microsoft.AspNetCore.Mvc;
using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Response;
using ReservationManagementSystem.Service.WorkerClient;

namespace ReservationManagementSystem.Controller;

[ApiController]
[Route("api/workerclient")]
public class WorkerClientController(IWorkerClientService workerClientService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetWorkerClients([FromQuery] WorkerClientFilter filter)
        => Ok(ApiResponse<PaginationResponse<IEnumerable<ReadWorkerClient>>>.Success(null,
            workerClientService.GetAll(filter)));
    
    [HttpGet("{id:int}")]
    public IActionResult GetWorkerClientById(int id)
    {
        ReadWorkerClient? res = workerClientService.GetById(id);
        return res != null
            ? Ok(ApiResponse<ReadWorkerClient?>.Success(null, res))
            : NotFound(ApiResponse<ReadWorkerClient?>.Fail(null, null));
    }
    
    [HttpPost]
    public IActionResult CreateWorkerClient([FromBody] int workerId, int clientId)
    {
        CreateWorkerClient workerClient = new CreateWorkerClient(workerId,clientId);
        bool res = workerClientService.Create(workerClient);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : BadRequest(ApiResponse<bool>.Fail(null, res));
    }
    
    [HttpPut]
    public IActionResult UpdateWorkerClient(UpdateWorkerClient workerClient)
    {
        bool res = workerClientService.Update(workerClient);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteWorkerClient(int id)
    {
        bool res = workerClientService.Delete(id);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
}