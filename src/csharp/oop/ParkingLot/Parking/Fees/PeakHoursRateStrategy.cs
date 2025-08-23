namespace ParkingLot.Parking.Fees;

public sealed class PeakHoursRateStrategy(decimal multiplier) : IHourRateStrategy
{
    public decimal Calculate(Ticket ticket, DateTimeOffset startTime, decimal currentRate)
    {
        if (startTime.Hour is >= 12 and <= 15)
        {
            return currentRate * multiplier;
        }

        return currentRate;
    }
}