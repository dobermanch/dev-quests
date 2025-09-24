package states

import "fmt"

type WaitForDepositState struct {
	*StateContext
}

func WaitForDeposit(context *StateContext) MachineState {
	if context.Manager.MissingAmount > 0 {
		context.Manager.display.Notify(fmt.Sprintf("Not enough money, please add '%f'", context.Manager.MissingAmount))
	} else {
		context.Manager.display.Notify("Please insert money")
	}

	return &WaitForDepositState{
		context,
	}
}

func (s *WaitForDepositState) Process() {
	if s.Manager.Balance <= 0 {
		s.Manager.display.Notify("Please insert money")
		return
	}

	s.Manager.display.Notify(fmt.Sprintf("Current balance '%f'", s.Manager.Balance))
	if s.Manager.MissingAmount > 0 {
		s.Manager.NextState(ProcessPayment(s.StateContext), true)
	} else {
		s.Manager.NextState(SelectProduct(s.StateContext), false)
	}
}
