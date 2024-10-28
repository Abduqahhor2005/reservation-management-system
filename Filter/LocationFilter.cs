namespace ReservationManagementSystem.Filter;

public record LocationFilter : BaseFilter
{
    public string? Country { get; init; }
    public string? City { get; init; }
    public string? Region { get; init; }
    public string? Address { get; init; }
}