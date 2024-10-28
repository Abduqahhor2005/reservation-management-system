using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Entities;

namespace ReservationManagementSystem.Mapper;

public static class LocationMapper
{
    public static ReadLocation ReadToLocation(this Location location)
        => new ReadLocation()
        {
            Id = location.Id,
            Country = location.Country,
            City = location.City,
            Region = location.Region,
            Address = location.Address
        };
    
    public static Location UpdateToLocation(this Location location, UpdateLocation updateLocation)
    {
        location.Id = updateLocation.Id;
        location.Country = updateLocation.Country;
        location.City = updateLocation.City;
        location.Region = updateLocation.Region;
        location.Address = updateLocation.Address;
        return location;
    }

    public static Location CreateToLocation(this CreateLocation createLocation)
        => new Location()
        {
            Country = createLocation.Country,
            City = createLocation.City,
            Region = createLocation.Region,
            Address = createLocation.Address
        };

    public static Location DeleteToLocation(this Location location)
    {
        location.IsDeleted = true;
        location.DeletedAt = DateTime.UtcNow;
        location.UpdatedAt = DateTime.UtcNow;
        return location;
    }
}