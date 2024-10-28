using ReservationManagementSystem.DTOs;
using ReservationManagementSystem.Filter;
using ReservationManagementSystem.Response;

namespace ReservationManagementSystem.Service.Client;

public interface IClientService
{
    PaginationResponse<IEnumerable<ReadClient>> GetAll(ClientFilter filter);
    ReadClient? GetById(int id);
    bool Create(CreateClient client);
    bool Update(UpdateClient client);
    bool Delete(int id);
}