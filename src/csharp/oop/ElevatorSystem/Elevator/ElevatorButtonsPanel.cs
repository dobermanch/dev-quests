namespace ElevatorSystem.Elevator;

public class ElevatorButtonsPanel(ElevatorCabin elevator, ElevatorSystem elevatorSystem)
{
    public IReadOnlyCollection<int> GetFloorButtons()
        => elevator.Floors;

    public void PressButton(int floor)
    {
        if (elevator.Floors.Contains(floor))
        {
            elevatorSystem.RequestFloor(elevator, floor);
        }
    }
}
