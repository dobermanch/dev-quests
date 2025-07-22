namespace ParkingLot.Parking.Fees;

public sealed class HourBaseRateStrategy : IHourRateStrategy
{
    public decimal Calculate(Ticket ticket, DateTimeOffset startTime, decimal currentRate)
    {
        // Rates can be configured if needed
        return ticket.Vehicle.Size switch
        {
            VehicleSizeType.Normal => 1.2m,
            VehicleSizeType.Oversize => 1.4m,
            _ => 1.0m
        };
    }
}