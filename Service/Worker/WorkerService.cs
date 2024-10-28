using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Mapper;
using ReservationManagementSystem.Response;

namespace ReservationManagementSystem.Service.Worker;

public class WorkerService(DataContext context) : IWorkerService
{
    public PaginationResponse<IEnumerable<ReadWorker>> GetAll(WorkerFilter filter)
    {
        try
        {
            IQueryable<Entities.Worker> workers = context.Workers;
            if (filter.Name != null)
                workers = workers.Where(x => x.FullName.ToLower()
                    .Contains(filter.Name.ToLower()));
            if (filter.Age != null)
                workers = workers.Where(x => x.Age == filter.Age);
            if (filter.Email != null)
                workers = workers.Where(x => x.Email!.ToLower()
                    .Contains(filter.Email.ToLower()));
            if (filter.PhoneNumber != null)
                workers = workers.Where(x => x.PhoneNumber!.ToLower()
                    .Contains(filter.PhoneNumber.ToLower()));
            if (filter.Payment != null)
                workers = workers.Where(x => x.Payment == filter.Payment);
            if (filter.Status != null)
                workers = workers.Where(x => x.Status == filter.Status);
            if (filter.Profession != null)
                workers = workers.Where(x => x.Profession!.ToLower()
                    .Contains(filter.Profession!.ToLower()));
            if (filter.PhoneNumber != null)
                workers = workers.Where(x => x.StartTime == filter.StartTime);
            if (filter.PhoneNumber != null)
                workers = workers.Where(x => x.EndTime == filter.EndTime);
            IQueryable<ReadWorker> result = workers.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).Select(x=>x.ReadToWorker());
            int totalRecords = context.Workers.Count();
            return PaginationResponse<IEnumerable<ReadWorker>>.
                Create(filter.PageNumber, filter.PageSize, totalRecords, result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public ReadWorker? GetById(int id)
    {
        try
        {
            var worker = (from u in context.Workers
                where u.IsDeleted == false && u.Id==id
                select u.ReadToWorker()).FirstOrDefault();
            return worker;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Create(CreateWorker worker)
    {
        try
        {
            bool existWorker = context.Workers.Any(x =>
                x.Email.ToLower() == worker.Email.ToLower() && x.IsDeleted == false);
            if (existWorker) return false;  
            context.Workers.Add(worker.CreateToWorker());
            context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Update(UpdateWorker updateWorker)
    {
        try
        {
            Entities.Worker? worker = context.Workers.
                FirstOrDefault(x => x.IsDeleted == false && x.Id == updateWorker.Id);
            if (worker is null) return false;
            context.Workers.Update(worker.UpdateToWorker(updateWorker));
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
            Entities.Worker? worker = context.Workers.FirstOrDefault(x => x.Id == id);
            if (worker is null) return false;
            worker.DeleteToWorker();
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