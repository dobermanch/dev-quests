package main

import (
	"fmt"

	"github.com/dobermanch/dev-quests/elevator/internal"
)

func main() {
	floors := []int{}
	oddFloors := []int{}
	evenFloors := []int{}

	for i := range 30 {
		floors = append(floors, i)
		if i%2 == 0 {
			evenFloors = append(evenFloors, i)
		} else {
			oddFloors = append(oddFloors, i)
		}
	}

	elevator1 := internal.ElevatorCar("Elevator 1", floors)
	elevator2 := internal.ElevatorCar("Elevator 2", evenFloors)
	elevator3 := internal.ElevatorCar("Elevator 3", oddFloors)

	system := internal.System([]*internal.Elevator{&elevator1, &elevator2, &elevator3})

	controls := internal.HoleControls(10, system)
	controls.PressUp()
	controls = internal.HoleControls(15, system)
	controls.PressDown()
	controls = internal.HoleControls(29, system)
	controls.PressDown()
	controls = internal.HoleControls(30, system)
	controls.PressDown()
	controls = internal.HoleControls(1, system)
	controls.PressUp()

	for _, status := range system.GetElevatorStatuses() {
		fmt.Printf("%s: %d %d\n", status.ElevatorId, status.CurrentFloor, status.Direction)
	}

	elevator1.Panel.RequestFloor(15)
	elevator1.Panel.RequestFloor(30)
	elevator1.Panel.RequestFloor(17)
}

// def _go_one_floor(self):
//     if len(self._queue) <= 0:
//         self._status = ElevatorStatus(self._id, self._status.current_floor, Direction.IDLE)
//         return

//     next_floor = self._queue[0]
//     if self._status.current_floor > next_floor:
//         self._status = ElevatorStatus(self._id, self._status.current_floor - 1, Direction.DOWN)
//     elif self._status.current_floor < next_floor:
//         self._status = ElevatorStatus(self._id, self._status.current_floor + 1, Direction.UP)
//     else:
//         self._queue = self._queue[1:]

//         if len(self._queue) > 0:
//             return

//         self._status = ElevatorStatus(self._id, self._status.current_floor, Direction.IDLE)

//         if len(self._delayed_queue) <= 0:
//             return

//         floor = self._delayed_queue[0]
//         self._delayed_queue = self._delayed_queue[1:]

//         self._queue.append(floor)
//         self._status = ElevatorStatus(self._id, self._status.current_floor, Direction.DOWN if self._status.current_floor > floor else Direction.UP)
