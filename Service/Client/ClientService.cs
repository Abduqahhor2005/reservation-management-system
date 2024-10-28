using Microsoft.EntityFrameworkCore;
using Npgsql;
using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Mapper;
using ReservationManagementSystem.Response;

namespace ReservationManagementSystem.Service.Client;

public class ClientService(DataContext context) : IClientService
{
    public PaginationResponse<IEnumerable<ReadClient>> GetAll(ClientFilter filter)
    {
        try
        {
            IQueryable<Entities.Client> clients = context.Clients;
            if (filter.Name != null)
                clients = clients.Where(x => x.FullName.ToLower()
                    .Contains(filter.Name.ToLower()));
            if (filter.Age != null)
                clients = clients.Where(x => x.Age == filter.Age);
            if (filter.Email != null)
                clients = clients.Where(x => x.Email!.ToLower()
                    .Contains(filter.Email.ToLower()));
            if (filter.PhoneNumber != null)
                clients = clients.Where(x => x.PhoneNumber!.ToLower()
                    .Contains(filter.PhoneNumber.ToLower()));
            if (filter.StartTime != null)
                clients = clients.Where(x => x.StartTime == filter.StartTime);
            if (filter.EndTime != null)
                clients = clients.Where(x => x.EndTime == filter.EndTime);
            IQueryable<ReadClient> result = clients.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).Select(x=>x.ReadToClient());
            int totalRecords = context.Clients.Count();
            return PaginationResponse<IEnumerable<ReadClient>>.
                Create(filter.PageNumber, filter.PageSize, totalRecords, result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public ReadClient? GetById(int id)
    {
        try
        {
            var client = (from u in context.Clients
                where u.IsDeleted == false && u.Id==id
                select u.ReadToClient()).FirstOrDefault();
            return client;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Create(CreateClient client)
    {
        try
        {
            bool existClient = context.Clients
                .Any(c => 
                    (c.StartTime < client.EndTime && c.EndTime > client.StartTime) &&
                    c.LocationId == client.LocationId);

            if (existClient) return false;

            context.Clients.Add(client.CreateToClient());
            context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Update(UpdateClient updateClient)
    {
        try
        {
            Entities.Client? client = context.Clients.
                FirstOrDefault(x => x.IsDeleted == false && x.Id == updateClient.Id);
            if (client is null) return false;
            context.Clients.Update(client.UpdateToClient(updateClient));
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
            Entities.Client? client = context.Clients.FirstOrDefault(x => x.Id == id);
            if (client is null) return false;
            client.DeleteToClient();
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