using ParkingLot;
using ParkingLot.Parking;
using ParkingLot.Parking.Fees;
using ParkingLot.Parking.ParkingAssistant;

Console.WriteLine($"Args: {args[0]}");

var sizes = Enum.GetValues<VehicleSizeType>();
var parkinManager = new ParkingAssistantManager(
    Enumerable.Range(0, 100)
        .Select(it => new ParkingSpot(it.ToString(), sizes[it % 3]))
        .ToArray(),
    new FirstAvailableParkingSpotFindStrategy());
var feeCalculator = new FeeCalculator([
    new HourBaseRateStrategy(),
    new PeakHoursRateStrategy(1.5m)
]);
var parkingLot = new ParkingLot.Parking.ParkingSystem(parkinManager, feeCalculator);

Ticket ticket = parkingLot.ParkVehicle(new Vehicle(VehicleSizeType.Normal, "123"));

await Task.Delay(5000);

Receipt receipt = parkingLot.UnparkVehicle(ticket);

Console.WriteLine(receipt);