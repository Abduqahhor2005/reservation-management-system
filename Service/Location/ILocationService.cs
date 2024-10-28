using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Response;

namespace ReservationManagementSystem.Service.Location;

public interface ILocationService
{
    PaginationResponse<IEnumerable<ReadLocation>> GetAll(LocationFilter filter);
    ReadLocation? GetById(int id);
    bool Create(CreateLocation location);
    bool Update(UpdateLocation location);
    bool Delete(int id);
}