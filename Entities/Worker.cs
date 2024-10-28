namespace ReservationManagementSystem.Entities;

public sealed class Worker : Person
{
    public string Profession { get; set; } = null!;
    public double Payment { get; set; }
    public Status Status { get; set; }
    public int LocationId { get; set; }
    public Location? Location { get; set; }
    public List<WorkerClient> WorkerClients { get; set; } = [];
}