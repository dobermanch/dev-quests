package internal

type ElevatorSystem interface {
	GetElevatorStatuses() []ElevatorStatus
	CallElevator(floor int, direction Direction) (*Elevator, error)
	RequestFloor(elevator Elevator, floor int)
}

type ElevatorSystemImpl struct {
	elevators  []*Elevator
	dispatcher *Dispatcher
}

func System(elevators []*Elevator) ElevatorSystem {
	return &ElevatorSystemImpl{
		elevators: elevators,
		dispatcher: &Dispatcher{
			elevators: elevators,
		},
	}
}

func (s *ElevatorSystemImpl) GetElevatorStatuses() []ElevatorStatus {
	statuses := []ElevatorStatus{}

	for _, elevator := range s.elevators {
		statuses = append(statuses, elevator.GetStatus())
	}

	return statuses
}

func (s *ElevatorSystemImpl) CallElevator(floor int, direction Direction) (*Elevator, error) {
	return s.dispatcher.CallElevator(floor, direction)
}

func (s *ElevatorSystemImpl) RequestFloor(elevator Elevator, floor int) {
	elevator.UserRequestedFloor(floor)
}
