package states

type IdleState struct{}

func Idle(manager *StateManager) MachineState {
	manager.ResetState()
	return WaitForDeposit(&StateContext{
		Manager: manager,
	})
}

func (IdleState) Process() {}
