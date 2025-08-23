using ParkingLot.Parking.Fees;
using ParkingLot.Parking.ParkingAssistant;

namespace ParkingLot.Parking;
public sealed class ParkingSystem(IParkingAssistant parkingAssistant, IFeeCalculator feeCalculator)
{
    public Ticket ParkVehicle(Vehicle vehicle) => parkingAssistant.ParkVehicle(vehicle);

    public Receipt UnparkVehicle(Ticket ticket)
    {
        if (ticket.Invalid)
        {
            throw new InvalidOperationException("Invalid ticket");
        }
        
        ticket = parkingAssistant.UnparkVehicle(ticket);
        decimal feeAmount = feeCalculator.Calculate(ticket);
        
        return new Receipt(
            Guid.NewGuid().ToString(),
            feeAmount,
            ticket.Vehicle,
            ticket.ParkTime,
            ticket.LeaveTime!.Value);
    }
}