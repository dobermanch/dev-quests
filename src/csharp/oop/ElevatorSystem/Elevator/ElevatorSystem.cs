namespace ElevatorSystem.Elevator;

public class ElevatorSystem(IList<ElevatorCabin> elevators, Dispatcher dispatcher)
{
    public IReadOnlyCollection<ElevatorCabin> GetElevators()
        => elevators.ToArray();

    public IReadOnlyCollection<ElevatorStatus> GetElevatorStatuses()
        => elevators.Select(it => it.Status).ToArray();

    public ElevatorCabin? CallElevator(int floor, Direction direction)
        => dispatcher.CallElevator(floor, direction);

    public void RequestFloor(ElevatorCabin elevator, int floor)
    {
        if (elevator == null)
        {
            throw new ArgumentNullException(nameof(elevator));
        }

        elevator.RequestFloor(floor);
    }
}
