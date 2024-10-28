using Microsoft.EntityFrameworkCore;
using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Mapper;
using ReservationManagementSystem.Response;

namespace ReservationManagementSystem.Service.Location;

public class LocationService(DataContext context) : ILocationService
{
    public PaginationResponse<IEnumerable<ReadLocation>> GetAll(LocationFilter filter)
    {
        try
        {
            IQueryable<Entities.Location> locations = context.Locations;
            if (filter.Country != null)
                locations = locations.Where(x => x.Country.ToLower()
                    .Contains(filter.Country.ToLower()));
            if (filter.City != null)
                locations = locations.Where(x => x.City.ToLower()
                    .Contains(filter.City.ToLower()));
            if (filter.Region != null)
                locations = locations.Where(x => x.Region!.ToLower()
                    .Contains(filter.Region.ToLower()));
            if (filter.Address != null)
                locations = locations.Where(x => x.Address!.ToLower()
                    .Contains(filter.Address.ToLower()));
            IQueryable<ReadLocation> result = locations.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize).Select(x=>x.ReadToLocation());
            int totalRecords = context.Locations.Count();
            return PaginationResponse<IEnumerable<ReadLocation>>.
                Create(filter.PageNumber, filter.PageSize, totalRecords, result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public ReadLocation? GetById(int id)
    {
        try
        {
            var location = (from u in context.Locations
                where u.IsDeleted == false && u.Id==id
                select u.ReadToLocation()).FirstOrDefault();
            return location;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Create(CreateLocation location)
    {
        try
        {
            bool existLocation = context.Locations.Any(x =>
                x.Address.ToLower() == location.Address.ToLower() && x.IsDeleted == false);
            if (existLocation) return false;
            context.Locations.Add(location.CreateToLocation());
            context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool Update(UpdateLocation updateLocation)
    {
        try
        {
            Entities.Location? existLocation = context.Locations.
                FirstOrDefault(x => x.IsDeleted == false && x.Id == updateLocation.Id);
            if (existLocation == null) return false;
            context.Locations.Update(existLocation.UpdateToLocation(updateLocation));
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
            Entities.Location? existLocation = context.Locations.FirstOrDefault(x => x.Id == id);
            if (existLocation == null) return false;
            existLocation.DeleteToLocation();
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