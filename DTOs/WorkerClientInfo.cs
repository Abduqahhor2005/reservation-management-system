namespace ReservationManagementSystem.DTOs;

public readonly record struct ReadWorkerClient(
    int Id,
    int WorkerId,
    int ClientId);
    
public readonly record struct CreateWorkerClient(
    int WorkerId,
    int ClientId);

public readonly record struct UpdateWorkerClient(
    int Id,
    int WorkerId,
    int ClientId);