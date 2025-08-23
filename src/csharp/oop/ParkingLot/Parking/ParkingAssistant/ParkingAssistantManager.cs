using System.Collections.Frozen;

namespace ParkingLot.Parking.ParkingAssistant;

public sealed class ParkingAssistantManager : IParkingAssistant
{
    private readonly IParkingSpotFindStrategy _findStrategy;
    private readonly TimeProvider _timeProvider;
    private readonly FrozenDictionary<VehicleSizeType, List<ParkingSpot>> _availableSpots;
    private readonly Dictionary<Vehicle, ParkingSpot> _occupiedLots = new();

    public ParkingAssistantManager(IList<ParkingSpot> spots, IParkingSpotFindStrategy findStrategy, TimeProvider? timeProvider = null)
    {
        _findStrategy = findStrategy;
        _timeProvider = timeProvider ?? TimeProvider.System;
        _availableSpots = spots
            .GroupBy(it => it.Size)
            .ToFrozenDictionary(it => it.Key, it => it.ToList());
    }

    public Ticket ParkVehicle(Vehicle vehicle)
    {
        // Validate vehicle, it cannot be parked twice
        
        ParkingSpot? spot = _findStrategy.FindSpot(_availableSpots, vehicle);
        if (spot == null)
        {
            return new Ticket(vehicle, null, _timeProvider.GetUtcNow());
        }

        var ticket = new Ticket(vehicle, spot, _timeProvider.GetUtcNow());

        _availableSpots[spot.Size].Remove(spot);
        _occupiedLots.Add(vehicle, spot);

        return ticket;
    }

    public Ticket UnparkVehicle(Ticket ticket)
    {
        ticket.LeaveTime = _timeProvider.GetUtcNow();

        if (_occupiedLots.TryGetValue(ticket.Vehicle, out var spot))
        {
            _availableSpots[spot.Size].Add(spot);
            _occupiedLots.Remove(ticket.Vehicle);
        }

        return ticket;
    }
}