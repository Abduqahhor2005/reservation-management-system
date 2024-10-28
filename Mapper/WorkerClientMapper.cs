using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Entities;

namespace ReservationManagementSystem.Mapper;

public static class WorkerClientMapper
{
    public static ReadWorkerClient ReadToWorkerClient(this WorkerClient workerClient)
        => new ReadWorkerClient()
        {
            Id = workerClient.Id,
            WorkerId = workerClient.WorkerId,
            ClientId = workerClient.ClientId
        };
    
    public static WorkerClient UpdateWorkerClient(this WorkerClient workerClient, UpdateWorkerClient updateWorkerClient)
    {
        workerClient.Id = updateWorkerClient.Id;
        workerClient.WorkerId = updateWorkerClient.WorkerId;
        workerClient.ClientId = updateWorkerClient.ClientId;
        workerClient.UpdatedAt = DateTime.UtcNow;
        return workerClient;
    }

    public static WorkerClient CreateToWorkerClient(this CreateWorkerClient createWorkerClient)
        => new WorkerClient()
        {
            WorkerId = createWorkerClient.WorkerId,
            ClientId = createWorkerClient.ClientId
        };

    public static WorkerClient DeleteToWorkerClient(this WorkerClient workerClient)
    {
        workerClient.IsDeleted = true;
        workerClient.DeletedAt = DateTime.UtcNow;
        workerClient.UpdatedAt = DateTime.UtcNow;
        return workerClient;
    }
}