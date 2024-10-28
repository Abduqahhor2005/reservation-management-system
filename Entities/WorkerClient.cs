namespace ReservationManagementSystem.Entities;

public class WorkerClient : BaseEntity
{
    public int Id { get; set; }
    
    public int WorkerId { get; set; }
    public Worker Worker { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }
}