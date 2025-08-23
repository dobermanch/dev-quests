namespace ParkingLot.Parking.ParkingAssistant;

public sealed class FirstAvailableParkingSpotFindStrategy : IParkingSpotFindStrategy
{
    private readonly VehicleSizeType[] _types = Enum.GetValues<VehicleSizeType>();

    public ParkingSpot? FindSpot(IReadOnlyDictionary<VehicleSizeType, List<ParkingSpot>> availableSpots, Vehicle vehicle)
    {
        foreach (var size in _types.Where(it => it >= vehicle.Size))
        {
            if (!availableSpots.TryGetValue(size, out List<ParkingSpot>? spots) || spots.Count <= 0)
            {
                continue;
            }

            ParkingSpot? spot = spots.FirstOrDefault();
            if (spot != null)
            {
                return spot;
            }
        }
        
        return null;
    }
}