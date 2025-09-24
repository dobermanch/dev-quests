package states

type CompleteOrderState struct{}

func CompleteOrder(context *StateContext) MachineState {
	context.Manager.display.Notify("Thank you for purchase")
	return Idle(context.Manager)
}

func (s *CompleteOrderState) Process() {}
