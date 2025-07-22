using ParkingLot.Parking;
using ParkingLot.Parking.Fees;
using ParkingLot.Parking.ParkingAssistant;

namespace ParkingLot.Tests;

public class ParkingLotTests
{
    private readonly TimeProviderMock _timeMock = new ();
    private readonly VehicleSizeType[] _vehicleSizes = Enum.GetValues<VehicleSizeType>();
    
    [Fact]
    public void ShouldParkVehicleAndCalculateCorrectPrice()
    {
        var parkinManager = new ParkingAssistantManager(
            Enumerable.Range(0, 10)
                .Select(it => new ParkingSpot(it.ToString(), _vehicleSizes[it % 3]))
                .ToArray(),
            new FirstAvailableParkingSpotFindStrategy(),
            _timeMock);
        var feeCalculator = new FeeCalculator([
            new HourBaseRateStrategy(),
            new PeakHoursRateStrategy(1.5m)
        ]);
        
        var parkingLot = new Parking.ParkingSystem(parkinManager, feeCalculator);

        Ticket ticket = parkingLot.ParkVehicle(new Vehicle(VehicleSizeType.Normal, "123"));
        
        _timeMock.Advance(TimeSpan.FromHours(2));
        
        Receipt receipt = parkingLot.UnparkVehicle(ticket);
        
        Assert.Equal(2.4m, receipt.Price);
    }
    
    [Fact]
    public void ShouldNotReassignParkinSpots()
    {
        var parkinManager = new ParkingAssistantManager(
            Enumerable.Range(0, 10)
                .Select(it => new ParkingSpot(it.ToString(), _vehicleSizes[it % 3]))
                .ToArray(),
            new FirstAvailableParkingSpotFindStrategy(),
            _timeMock);
        var feeCalculator = new FeeCalculator([
            new HourBaseRateStrategy(),
            new PeakHoursRateStrategy(1.5m)
        ]);
        
        var parkingLot = new Parking.ParkingSystem(parkinManager, feeCalculator);

        Ticket ticket1 = parkingLot.ParkVehicle(new Vehicle(VehicleSizeType.Normal, "123"));
        Ticket ticket2 = parkingLot.ParkVehicle(new Vehicle(VehicleSizeType.Normal, "1234"));
        Ticket ticket3 = parkingLot.ParkVehicle(new Vehicle(VehicleSizeType.Normal, "12345"));
        
        HashSet<string> set = [ticket1.ParkingSpot!.Number, ticket2.ParkingSpot!.Number, ticket3.ParkingSpot!.Number];
        
        Assert.Equal(3, set.Count);
    }
}

class TimeProviderMock(DateTimeOffset? time = null) : TimeProvider
{
    private DateTimeOffset _time = time ?? DateTimeOffset.UtcNow;
    
    public override DateTimeOffset GetUtcNow() => _time;

    public void Advance(TimeSpan time) => _time = _time.Add(time);
}
