package states

import "fmt"

type ReturnChangeState struct {
	*StateContext
}

func ReturnChange(context *StateContext) MachineState {
	if context.Manager.Change <= 0 {
		return CompleteOrder(context)
	} else {
		context.Manager.display.Notify(fmt.Sprintf("Please peak up the change: %f", context.Manager.Change))
	}
	return &ReturnChangeState{
		context,
	}
}

func (s *ReturnChangeState) Process() {
	s.Manager.Change = 0
	s.Manager.NextState(CompleteOrder(s.StateContext), true)
}
