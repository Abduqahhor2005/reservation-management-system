namespace ReservationManagementSystem.DTOs;

public readonly record struct ReadClient(
    int Id,
    string FullName, 
    int Age, 
    string Email,
    string PhoneNumber,
    TimeSpan StartTime,
    TimeSpan EndTime,
    int LocationId);
    
public readonly record struct CreateClient(
    string FullName, 
    int Age, 
    string Email,
    string PhoneNumber,
    TimeSpan StartTime,
    TimeSpan EndTime,
    int LocationId);

public readonly record struct UpdateClient(
    int Id,
    string FullName, 
    int Age, 
    string Email,
    string PhoneNumber,
    TimeSpan StartTime,
    TimeSpan EndTime,
    int LocationId);    