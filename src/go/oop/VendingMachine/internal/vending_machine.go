package internal

import (
	"fmt"

	internal "github.com/dobermanch/dev-quests/vending-machine/internal/inventory"
	"github.com/dobermanch/dev-quests/vending-machine/internal/models"
	"github.com/dobermanch/dev-quests/vending-machine/internal/notifications"
	"github.com/dobermanch/dev-quests/vending-machine/internal/states"
)

type VendingMachine struct {
	inventoryManager internal.Inventory
	display          notifications.Notification
	state            *states.StateManager
}

func New() VendingMachine {
	inventory := internal.Manager()
	display := notifications.Display{}
	return VendingMachine{
		inventoryManager: inventory,
		display:          &display,
		state:            states.NewState(&display, inventory),
	}
}

func (vm *VendingMachine) AddProduct(rankNumber string, product models.Product, count int) {
	err := vm.inventoryManager.AddProduct(rankNumber, product, count)
	if err != nil {
		vm.display.Notify(err)
	} else {
		vm.display.Notify(fmt.Sprintf("Added %s (%d) product to the %s rack", product.Name, count, rankNumber))
	}
}

func (vm *VendingMachine) InsertMoney(balance float32) {
	vm.state.InsertMoney(balance)
}

func (vm *VendingMachine) SelectProduct(code string) {
	vm.state.SelectProduct(code)
}

func (vm *VendingMachine) PickupChange() {
	vm.state.PickupChange()
}

func (vm *VendingMachine) DispenseProduct() {
	vm.state.DispenseProduct()
}
