using ReservationManagementSystem.Entities;

namespace ReservationManagementSystem.DTOs;

public readonly record struct ReadWorker(
    int Id, 
    string FullName, 
    int Age, 
    string Email,
    string PhoneNumber,
    TimeSpan StartTime,
    TimeSpan EndTime,
    string Profession,
    double Payment,
    Status Status, 
    int LocationId);
    
public readonly record struct CreateWorker(
    string FullName, 
    int Age, 
    string Email,
    string PhoneNumber,
    TimeSpan StartTime,
    TimeSpan EndTime,
    string Profession,
    double Payment,
    Status Status, 
    int LocationId);
    
public readonly record struct UpdateWorker(
    int Id,
    string FullName, 
    int Age, 
    string Email,
    string PhoneNumber,
    TimeSpan StartTime,
    TimeSpan EndTime,
    string Profession,
    double Payment,
    Status Status, 
    int LocationId);    