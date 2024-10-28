namespace ReservationManagementSystem.Filter;

public record ClientFilter : BaseFilter
{
    public string? Name { get; init; }
    public int? Age { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
}