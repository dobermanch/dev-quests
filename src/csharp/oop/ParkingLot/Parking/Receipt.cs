namespace ParkingLot.Parking;

public sealed record Receipt(
    string Number,
    decimal Price,
    Vehicle Vehicle,
    DateTimeOffset ParkTime,
    DateTimeOffset LeaveTime
);