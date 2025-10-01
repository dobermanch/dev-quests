package internal

type ElevatorPanel struct {
	elevator Elevator
}

func ElevatorCarPanel(elevator Elevator) ElevatorPanel {
	return ElevatorPanel{
		elevator: elevator,
	}
}

func (p *ElevatorPanel) RequestFloor(floor int) {
	if _, ok := p.elevator.Floors[floor]; ok {
		p.elevator.UserRequestedFloor(floor)
	}
}
