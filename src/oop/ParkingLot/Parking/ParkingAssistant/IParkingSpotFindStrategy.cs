namespace ParkingLot.Parking.ParkingAssistant;

public interface IParkingSpotFindStrategy
{
    ParkingSpot? FindSpot(IReadOnlyDictionary<VehicleSizeType, List<ParkingSpot>> availableSpots, Vehicle vehicle);
}