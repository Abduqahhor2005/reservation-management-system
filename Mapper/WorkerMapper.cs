using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Entities;

namespace ReservationManagementSystem.Mapper;

public static class WorkerMapper
{
    public static ReadWorker ReadToWorker(this Worker worker)
        => new ReadWorker()
        {
            Id = worker.Id,
            FullName = worker.FullName,
            Age = worker.Age,
            Email = worker.Email,
            PhoneNumber = worker.PhoneNumber,
            StartTime = worker.StartTime,
            EndTime = worker.EndTime,
            Profession = worker.Profession,
            Payment = worker.Payment,
            Status = worker.Status,
            LocationId = worker.LocationId
        };
    
    public static Worker UpdateToWorker(this Worker worker, UpdateWorker updateWorker)
    {
        worker.Id = updateWorker.Id;
        worker.FullName = updateWorker.FullName;
        worker.Age = updateWorker.Age;
        worker.Email = updateWorker.Email;
        worker.PhoneNumber = updateWorker.PhoneNumber;
        worker.StartTime = updateWorker.StartTime;
        worker.EndTime = updateWorker.EndTime;
        worker.Profession = updateWorker.Profession;
        worker.Payment = updateWorker.Payment;
        worker.Status = updateWorker.Status;
        worker.LocationId = updateWorker.LocationId;
        worker.UpdatedAt = DateTime.UtcNow;
        return worker;
    }

    public static Worker CreateToWorker(this CreateWorker createWorker)
        => new Worker()
        {
            FullName = createWorker.FullName,
            Age = createWorker.Age,
            Email = createWorker.Email,
            PhoneNumber = createWorker.PhoneNumber,
            StartTime = createWorker.StartTime,
            EndTime = createWorker.EndTime,
            Profession = createWorker.Profession,
            Payment = createWorker.Payment,
            Status = createWorker.Status,
            LocationId = createWorker.LocationId
        };

    public static Worker DeleteToWorker(this Worker worker)
    {
        worker.IsDeleted = true;
        worker.DeletedAt = DateTime.UtcNow;
        worker.UpdatedAt = DateTime.UtcNow;
        return worker;
    }
}