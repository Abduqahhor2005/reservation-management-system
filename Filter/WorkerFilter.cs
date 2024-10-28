using ReservationManagementSystem.Entities;

namespace ReservationManagementSystem.Filter;

public record WorkerFilter : BaseFilter
{
    public string? Name { get; init; }
    public int? Age { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public double? Payment { get; set; }
    public Status? Status { get; set; }
    public string? Profession { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
}