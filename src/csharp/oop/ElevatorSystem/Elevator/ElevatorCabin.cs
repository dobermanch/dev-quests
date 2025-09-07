namespace ElevatorSystem.Elevator;

public class ElevatorCabin(string id, IList<int> floors)
{
    internal List<int> _queue = new();
    private readonly Queue<int> _deferredQueue = new();

    public string Id { get; } = id;

    public IReadOnlySet<int> Floors { get; private set; } = floors.ToHashSet();

    public ElevatorStatus Status { get; private set; }

    public void RequestFloor(int floor)
    {
        if (_queue.Contains(floor) || !Floors.Contains(floor))
        {
            return;
        }

        if ((Status.Direction == Direction.Up && Status.CurrentFloor > floor)
            || (Status.Direction == Direction.Down && Status.CurrentFloor < floor))
        {
            return;
        }

        _queue.Add(floor);

        _queue = Status.CurrentFloor > floor
            ? _queue.OrderByDescending(it => it).ToList()
            : _queue.OrderBy(it => it).ToList();
    }

    public void RequestElevator(int floor, Direction direction)
    {
        if (_queue.Contains(floor))
        {
            return;
        }

        if ((Status.Direction == Direction.Up && Status.CurrentFloor > floor)
            || (Status.Direction == Direction.Down && Status.CurrentFloor < floor)
            || Status.Direction != direction)
        {
            if (!_deferredQueue.Contains(floor))
            {
                _deferredQueue.Enqueue(floor);
            }
            return;
        }

        _queue.Add(floor);

        _queue = Status.CurrentFloor > floor
            ? _queue.OrderByDescending(it => it).ToList()
            : _queue.OrderBy(it => it).ToList();
    }

    internal void GoOneFloor()
    {
        if (_queue.Count <= 0)
        {
            Status = new ElevatorStatus(id, Status.CurrentFloor, Direction.Idle);
            return;
        }

        var nextFloor = _queue[0];
        if (Status.CurrentFloor > nextFloor)
        {
            Status = new ElevatorStatus(id, Status.CurrentFloor - 1, Direction.Down);
        }
        else if (Status.CurrentFloor < nextFloor)
        {
            Status = new ElevatorStatus(id, Status.CurrentFloor + 1, Direction.Up);
        }
        else
        {
            _queue.RemoveAt(0);
            if (_queue.Count > 0)
            {
                return;
            }

            Status = new ElevatorStatus(id, Status.CurrentFloor, Direction.Idle);

            if (_deferredQueue.Count <= 0)
            {
                return;
            }

            var floor = _deferredQueue.Dequeue();

            _queue.Add(floor);
            Status = new ElevatorStatus(id, Status.CurrentFloor, Status.CurrentFloor > floor ? Direction.Down : Direction.Up);
        }
    }
}
