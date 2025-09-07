namespace ElevatorSystem.Elevator;

public class HoleButtonsPanel(int floor, ElevatorSystem elevatorSystem)
{
    public ElevatorCabin? PressUp()
        => elevatorSystem.CallElevator(floor, Direction.Up);

    public ElevatorCabin? PressDown()
        => elevatorSystem.CallElevator(floor, Direction.Down);
}
