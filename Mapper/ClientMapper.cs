using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Entities;

namespace ReservationManagementSystem.Mapper;

public static class ClientMapper
{
    public static ReadClient ReadToClient(this Client client)
        => new ReadClient()
        {
            Id = client.Id,
            FullName = client.FullName,
            Age = client.Age,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
            StartTime = client.StartTime,
            EndTime = client.EndTime,
            LocationId = client.LocationId
        };
    
    public static Client UpdateToClient(this Client client, UpdateClient updateClient)
    {
        client.Id = updateClient.Id;
        client.FullName = updateClient.FullName;
        client.Age = updateClient.Age;
        client.Email = updateClient.Email;
        client.PhoneNumber = updateClient.PhoneNumber;
        client.StartTime = updateClient.StartTime;
        client.EndTime = updateClient.EndTime;
        client.LocationId = updateClient.LocationId;
        client.UpdatedAt = DateTime.UtcNow;
        return client;
    }

    public static Client CreateToClient(this CreateClient createClient)
        => new Client()
        {
            FullName = createClient.FullName,
            Age = createClient.Age,
            Email = createClient.Email,
            PhoneNumber = createClient.PhoneNumber,
            StartTime = createClient.StartTime,
            EndTime = createClient.EndTime,
            LocationId = createClient.LocationId
        };

    public static Client DeleteToClient(this Client client)
    {
        client.IsDeleted = true;
        client.DeletedAt = DateTime.UtcNow;
        client.UpdatedAt = DateTime.UtcNow;
        return client;
    }
}