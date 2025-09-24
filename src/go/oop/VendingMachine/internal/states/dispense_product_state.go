package states

import "fmt"

type DispenseProductState struct {
	*StateContext
}

func DispenseProduct(context *StateContext) MachineState {
	context.Manager.display.Notify(fmt.Sprintf("Pick up the '%s' product", context.Manager.Rack.Product.Name))
	return &DispenseProductState{
		context,
	}
}

func (s *DispenseProductState) Process() {
	_, err := s.Manager.inventory.DispenseProduct(*s.Manager.RackNumber)
	if err != nil {
		s.Manager.display.Notify(err)
		s.Manager.NextState(SelectProduct(s.StateContext), false)
		return
	}
	s.Manager.NextState(ReturnChange(s.StateContext), false)
}
