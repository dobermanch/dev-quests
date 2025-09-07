namespace ElevatorSystem.Elevator;

public readonly record struct ElevatorStatus(string ElevatorId, int CurrentFloor, Direction Direction);
