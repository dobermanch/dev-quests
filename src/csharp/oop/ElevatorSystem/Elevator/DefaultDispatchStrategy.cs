namespace ElevatorSystem.Elevator;

public class DefaultDispatchStrategy : DispatchStrategyBase
{
    public override ElevatorCabin? FindElevator(IList<ElevatorCabin> elevators, int floor, Direction direction)
    {
        foreach (var elevator in elevators)
        {
            if (!elevator.Floors.Contains(floor))
            {
                continue;
            }

            if (elevator.Status.Direction == Direction.Idle)
            {
                return elevator;
            }

            if (elevator.Status.Direction == direction
                || ((elevator.Status.Direction == Direction.Down || elevator.Status.CurrentFloor > floor)
                    && (elevator.Status.Direction == Direction.Up || elevator.Status.CurrentFloor < floor)))
            {
                return elevator;
            }
        }

        return elevators[Random.Shared.Next(0, elevators.Count)];
    }
}
