package states

type MachineState interface {
	Process()
}

type StateContext struct {
	Manager *StateManager
}
