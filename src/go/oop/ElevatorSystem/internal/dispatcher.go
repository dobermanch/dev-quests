package internal

import (
	"fmt"
	"math/rand"
	"time"
)

type Dispatcher struct {
	elevators []*Elevator
}

func (d *Dispatcher) CallElevator(floor int, direction Direction) (*Elevator, error) {
	elevator := d.FindElevator(floor, direction)
	if elevator == nil {
		return nil, fmt.Errorf("elevator not found")
	}

	elevator.SystemRequestedFloor(floor, direction)

	return elevator, nil
}

func (d *Dispatcher) FindElevator(floor int, direction Direction) *Elevator {
	for _, elevator := range d.elevators {
		if _, ok := elevator.Floors[floor]; !ok {
			continue
		}

		status := elevator.GetStatus()
		if status.Direction == Idle {
			return elevator
		}

		if status.Direction == direction &&
			((status.Direction == Down && status.CurrentFloor > floor) ||
				(status.Direction == Up && status.CurrentFloor < floor)) {
			return elevator
		}
	}

	random := rand.New(rand.NewSource(time.Now().UnixNano()))
	i := random.Intn(len(d.elevators))
	return d.elevators[i]
}
