using ParkingLot.Parking.ParkingAssistant;

namespace ParkingLot.Parking;

public record Ticket(Vehicle Vehicle, ParkingSpot? ParkingSpot, DateTimeOffset ParkTime)
{
    public DateTimeOffset? LeaveTime { get; set; }
    public bool Invalid => ParkingSpot == null;
}