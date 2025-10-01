package internal

type HoleButtons struct {
	floor  int
	system ElevatorSystem
}

func HoleControls(floor int, system ElevatorSystem) HoleButtons {
	return HoleButtons{
		floor:  floor,
		system: system,
	}
}

func (c *HoleButtons) PressUp() {
	//check if this is last floor
	c.system.CallElevator(c.floor, Up)
}

func (c *HoleButtons) PressDown() {
	//check if this is first or some ground floor
	c.system.CallElevator(c.floor, Down)
}
