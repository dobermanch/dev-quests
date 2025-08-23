namespace ParkingLot.Parking.ParkingAssistant;

public interface IParkingAssistant
{
    Ticket ParkVehicle(Vehicle vehicle);
    Ticket UnparkVehicle(Ticket ticket);
}