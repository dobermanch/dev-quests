namespace ParkingLot.Parking.Fees;

public interface IHourRateStrategy
{
    decimal Calculate(Ticket ticket, DateTimeOffset startTime, decimal currentRate);
}