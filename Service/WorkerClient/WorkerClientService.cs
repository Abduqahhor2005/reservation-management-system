using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Mapper;
using ReservationManagementSystem.Response;

namespace ReservationManagementSystem.Service.WorkerClient;

public class WorkerClientService(DataContext context) : IWorkerClientService
{
    public PaginationResponse<IEnumerable<ReadWorkerClient>> GetAll(WorkerClientFilter filter)
    {
        try
        {
            IQueryable<ReadWorkerClient> result = context.WorkerClients.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).Select(x=>x.ReadToWorkerClient());
            int totalRecords = context.WorkerClients.Count();
            return PaginationResponse<IEnumerable<ReadWorkerClient>>.Create(filter.PageNumber, filter.PageSize,
                totalRecords, result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public ReadWorkerClient? GetById(int id)
    {
        try
        {
            var workerClient = (from u in context.WorkerClients
                where u.IsDeleted == false && u.Id==id
                select u.ReadToWorkerClient()).FirstOrDefault();
            return workerClient;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Create(CreateWorkerClient workerClient)
    {
        try
        {
            if (workerClient == null) return false;
            context.WorkerClients.Add(workerClient.CreateToWorkerClient());
            context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Update(UpdateWorkerClient updateWorkerClient) 
    {
        try
        {
            Entities.WorkerClient workerClient = context.WorkerClients.FirstOrDefault(x => 
                x.Id == updateWorkerClient.Id && x.IsDeleted == false)!;
            if (workerClient == null!) return false;
            context.WorkerClients.Update(workerClient.UpdateWorkerClient(updateWorkerClient));
            context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            Entities.WorkerClient? existClient = context.WorkerClients.FirstOrDefault(x => x.Id == id);
            if (existClient == null) return false;
            existClient.DeleteToWorkerClient();
            context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}