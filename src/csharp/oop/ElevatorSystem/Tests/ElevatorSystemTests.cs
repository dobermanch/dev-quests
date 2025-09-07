using ElevatorSystem.Elevator;
using Xunit.Abstractions;

namespace ElevatorSystem.Tests;

public class ElevatorSystemTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ElevatorSystemTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ElevatorShoutBeCalled()
    {
        var floors = Enumerable.Range(1, 30).ToArray();

        var elevators = new []{
            new ElevatorCabin("Elevator 1", floors),
            new ElevatorCabin("Elevator 2", floors.Where(it => it % 2 == 0).ToArray()),
            new ElevatorCabin("Elevator 3", floors.Where(it => it % 2 != 0).ToArray()),
        };

        var dispatcher = new Dispatcher(elevators, new DefaultDispatchStrategy());
        var system = new ElevatorSystem.Elevator.ElevatorSystem(elevators, dispatcher);

        new HoleButtonsPanel(10, system).PressUp();
        new HoleButtonsPanel(15, system).PressDown();
        new HoleButtonsPanel(29, system).PressDown();
        new HoleButtonsPanel(30, system).PressDown();
        new HoleButtonsPanel(1, system).PressUp();

        foreach (var status in system.GetElevatorStatuses())
        {
            _testOutputHelper.WriteLine($"{status.ElevatorId}: {status.CurrentFloor} {status.Direction.ToString()}");
        }

        var elevator = elevators[0];
        var buttons = new ElevatorButtonsPanel(elevator, system);
        buttons.PressButton(15);
        buttons.PressButton(30);
        buttons.PressButton(17);

        _testOutputHelper.WriteLine(string.Join(", ", elevator._queue));
        while (elevator._queue.Count > 0)
        {
            var next = elevator._queue[0];
            while (elevator.Status.CurrentFloor != next)
            {
                _testOutputHelper.WriteLine($"{elevator.Status.ElevatorId}: {elevator.Status.CurrentFloor} {elevator.Status.Direction.ToString()}");
                elevator.GoOneFloor();
            }

            _testOutputHelper.WriteLine($"{elevator.Status.ElevatorId} stopped at {elevator.Status.CurrentFloor}");
            elevator.GoOneFloor();

            if (elevator.Status.CurrentFloor != 15 || elevator.Status.Direction != Direction.Up)
                continue;

            buttons.PressButton(13);
            buttons.PressButton(20);
            elevator.RequestElevator(14, Direction.Up);
            elevator.RequestElevator(12, Direction.Up);
            elevator.RequestElevator(11, Direction.Down);
            _testOutputHelper.WriteLine(string.Join(", ", elevator._queue));
        }
    }
}
