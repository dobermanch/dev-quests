package states

import (
	internal "github.com/dobermanch/dev-quests/vending-machine/internal/inventory"
	"github.com/dobermanch/dev-quests/vending-machine/internal/models"
	"github.com/dobermanch/dev-quests/vending-machine/internal/notifications"
)

type StateManager struct {
	Balance       float32
	RackNumber    *string
	Rack          *models.Rack
	MissingAmount float32
	Change        float32

	currentState MachineState
	display      notifications.Notification
	inventory    internal.Inventory
}

func NewState(display notifications.Notification, inventory internal.Inventory) *StateManager {
	manager := &StateManager{
		display:   display,
		inventory: inventory,
	}

	manager.currentState = Idle(manager)

	return manager
}

func (m *StateManager) ResetState() {
	m.Balance = 0.0
	m.RackNumber = nil
	m.Rack = nil
	m.MissingAmount = 0.0
	m.Change = 0.0
}

func (m *StateManager) InsertMoney(balance float32) {
	_, ok := m.currentState.(*WaitForDepositState)
	if !ok {
		return
	}

	m.Balance += balance
	m.currentState.Process()
}

func (m *StateManager) SelectProduct(code string) {
	_, ok := m.currentState.(*SelectProductState)
	if !ok {
		return
	}

	m.RackNumber = &code
	m.currentState.Process()
}

func (m *StateManager) PickupChange() {
	_, ok := m.currentState.(*ReturnChangeState)
	if !ok {
		return
	}

	m.currentState.Process()
}

func (m *StateManager) DispenseProduct() {
	_, ok := m.currentState.(*DispenseProductState)
	if !ok {
		return
	}

	m.currentState.Process()
}

func (m *StateManager) NextState(state MachineState, execute bool) {
	m.currentState = state

	if execute {
		m.currentState.Process()
	}
}
