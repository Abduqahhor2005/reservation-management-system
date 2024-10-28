namespace ReservationManagementSystem.DTOs;

public readonly record struct ReadLocation(
    int Id,
    string Country, 
    string City, 
    string Region,
    string Address);
    
public readonly record struct CreateLocation(
    string Country, 
    string City, 
    string Region,
    string Address);

public readonly record struct UpdateLocation(
    int Id,
    string Country, 
    string City, 
    string Region,
    string Address);