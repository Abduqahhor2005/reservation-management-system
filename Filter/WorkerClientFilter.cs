namespace ReservationManagementSystem.Filter;

public record WorkerClientFilter : BaseFilter
{
    public int WorkerId { get; set; }
    public int ClientId { get; set; }
}