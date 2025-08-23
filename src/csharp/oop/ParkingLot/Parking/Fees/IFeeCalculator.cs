namespace ParkingLot.Parking.Fees;

public interface IFeeCalculator
{
    decimal Calculate(Ticket ticket);
}