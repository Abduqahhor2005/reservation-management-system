using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Response;

namespace ReservationManagementSystem.Service.Worker;

public interface IWorkerService
{
    PaginationResponse<IEnumerable<ReadWorker>> GetAll(WorkerFilter filter);
    ReadWorker? GetById(int id);
    bool Create(CreateWorker worker);
    bool Update(UpdateWorker worker);
    bool Delete(int id);
}