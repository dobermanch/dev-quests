package states

import "fmt"

type SelectProductState struct {
	*StateContext
}

func SelectProduct(context *StateContext) MachineState {
	context.Manager.display.Notify("Please select product code")
	return &SelectProductState{
		context,
	}
}

func (s *SelectProductState) Process() {
	if s.Manager.RackNumber == nil {
		s.Manager.display.Notify("Please select product code")
		return
	}

	rack, err := s.Manager.inventory.GetRack(*s.Manager.RackNumber)
	if err != nil {
		s.Manager.display.Notify(err)
		s.Manager.display.Notify("Please select product code")
		return
	}

	if !rack.IsEmpty() {
		s.Manager.Rack = rack
		s.Manager.display.Notify(fmt.Sprintf("Selected rack: %s", rack.Number))
		s.Manager.NextState(ProcessPayment(s.StateContext), true)
	} else {
		s.Manager.display.Notify(fmt.Sprintf("Selected '%s' rack is empty", rack.Number))
	}
}
