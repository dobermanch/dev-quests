namespace ElevatorSystem.Elevator;

public abstract class DispatchStrategyBase
{
    public abstract ElevatorCabin? FindElevator(IList<ElevatorCabin> elevators, int floor, Direction direction);
}
