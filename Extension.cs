using ReservationManagementSystem.Service.Client;
using ReservationManagementSystem.Service.Location;
using ReservationManagementSystem.Service.Worker;
using ReservationManagementSystem.Service.WorkerClient;

namespace ReservationManagementSystem;

public static class Extension
{
    public static void AddService(this IServiceCollection collection)
    {
        collection.AddScoped<IWorkerService,WorkerService>();
        collection.AddScoped<IClientService,ClientService>();
        collection.AddScoped<IWorkerClientService,WorkerClientService>();
        collection.AddScoped<ILocationService,LocationService>();
    }
}