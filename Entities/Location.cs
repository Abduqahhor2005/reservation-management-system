namespace ReservationManagementSystem.Entities;

public class Location : BaseEntity
{
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string Address { get; set; } = null!;
    public Worker? Worker { get; set; } 
    public Client? Client { get; set; } 
}