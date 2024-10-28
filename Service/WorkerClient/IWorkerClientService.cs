using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Response;

namespace ReservationManagementSystem.Service.WorkerClient;

public interface IWorkerClientService
{
    PaginationResponse<IEnumerable<ReadWorkerClient>> GetAll(WorkerClientFilter filter);
    ReadWorkerClient? GetById(int id);
    bool Create(CreateWorkerClient workerClient);
    bool Update(UpdateWorkerClient workerClient);
    bool Delete(int id);
}