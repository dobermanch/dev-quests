package states

type ProcessPaymentState struct {
	*StateContext
}

func ProcessPayment(context *StateContext) MachineState {
	context.Manager.display.Notify("Processing payment...")
	return &ProcessPaymentState{
		context,
	}
}

func (s *ProcessPaymentState) Process() {
	if s.Manager.Rack == nil {
		s.Manager.NextState(SelectProduct(s.StateContext), false)
		return
	}

	if s.Manager.Balance <= 0 {
		s.Manager.NextState(WaitForDeposit(s.StateContext), false)
		return
	}

	s.Manager.MissingAmount = 0.0
	if s.Manager.Rack.Product.Price > s.Manager.Balance {
		s.Manager.MissingAmount = s.Manager.Rack.Product.Price - s.Manager.Balance
		s.Manager.NextState(WaitForDeposit(s.StateContext), false)
		return
	}

	s.Manager.Change = s.Manager.Balance - s.Manager.Rack.Product.Price
	s.Manager.NextState(DispenseProduct(s.StateContext), false)
}
