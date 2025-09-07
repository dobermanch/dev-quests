namespace ElevatorSystem.Elevator;

public class Dispatcher(IList<ElevatorCabin> elevators, DispatchStrategyBase dispatchStrategy)
{
    public ElevatorCabin? CallElevator(int floor, Direction direction)
    {
        var elevator = dispatchStrategy.FindElevator(elevators, floor, direction);
        elevator?.RequestElevator(floor, direction);
        return elevator;
    }
}
