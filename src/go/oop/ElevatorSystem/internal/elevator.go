package internal

import "sort"

type Direction int

const (
	Idle Direction = iota
	Up
	Down
)

type Elevator struct {
	Id     string
	Floors map[int]bool
	Panel  *ElevatorPanel
	status ElevatorStatus

	requestMap    map[int]bool
	requestQueue  []int
	deferredQueue map[int]bool
}

type ElevatorStatus struct {
	ElevatorId   string
	CurrentFloor int
	Direction    Direction
}

func ElevatorCar(id string, floors []int) Elevator {
	sort.Slice(floors, func(i, j int) bool {
		return floors[i] < floors[j]
	})

	buttons := map[int]bool{}

	for _, floor := range floors {
		buttons[floor] = true
	}

	elevator := Elevator{
		Id:     id,
		Floors: buttons,
		status: ElevatorStatus{
			ElevatorId:   id,
			CurrentFloor: 1,
			Direction:    Idle,
		},
	}

	panel := ElevatorCarPanel(elevator)
	elevator.Panel = &panel

	return elevator
}

func (e *Elevator) GetStatus() ElevatorStatus {
	return e.status
}

func (e *Elevator) UserRequestedFloor(floor int) {
	if _, ok := e.Floors[floor]; !ok {
		return
	}

	if _, ok := e.requestMap[floor]; ok {
		return
	}

	if (e.status.Direction == Up && e.status.CurrentFloor > floor) ||
		(e.status.Direction == Down && e.status.CurrentFloor < floor) {
		return
	}

	e.requestMap[floor] = true
	e.requestQueue = append(e.requestQueue, floor)
	sort.Slice(e.requestQueue, func(i, j int) bool {
		if e.status.CurrentFloor > floor {
			return e.requestQueue[i] < e.requestQueue[j]
		}

		return e.requestQueue[i] > e.requestQueue[j]
	})
}

func (e *Elevator) SystemRequestedFloor(floor int, direction Direction) {
	if _, ok := e.Floors[floor]; !ok {
		return
	}

	if _, ok := e.requestMap[floor]; ok {
		return
	}

	if e.status.Direction == direction ||
		((e.status.Direction == Up && e.status.CurrentFloor > floor) ||
			(e.status.Direction == Down && e.status.CurrentFloor < floor)) {
		if _, ok := e.deferredQueue[floor]; !ok {
			e.deferredQueue[floor] = true
		}
		return
	}

	e.requestMap[floor] = true
	e.requestQueue = append(e.requestQueue, floor)
	sort.Slice(e.requestQueue, func(i, j int) bool {
		if e.status.CurrentFloor > floor {
			return e.requestQueue[i] < e.requestQueue[j]
		}

		return e.requestQueue[i] > e.requestQueue[j]
	})
}
