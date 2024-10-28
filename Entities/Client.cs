namespace ReservationManagementSystem.Entities;

public class Client : Person
{
    public int LocationId { get; set; }
    public Location? Location { get; set; }
    public List<WorkerClient> WorkerClients { get; set; } = [];
}