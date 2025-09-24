package internal

import (
	"fmt"

	"github.com/dobermanch/dev-quests/vending-machine/internal/models"
)

type Inventory interface {
	GetRack(rackNumber string) (*models.Rack, error)
	AddProduct(rackNumber string, product models.Product, count int) error
	DispenseProduct(rackNumber string) (*models.Product, error)
}

type InventoryManager struct {
	inventory map[string]*models.Rack
}

func Manager() Inventory {
	return &InventoryManager{
		inventory: make(map[string]*models.Rack),
	}
}

func (m *InventoryManager) GetRack(rackNumber string) (*models.Rack, error) {
	if rack, ok := m.inventory[rackNumber]; ok {
		return rack, nil
	}

	return nil, fmt.Errorf("the '%s' rack not found", rackNumber)
}

func (m *InventoryManager) AddProduct(rackNumber string, product models.Product, count int) error {
	if count <= 0 {
		return fmt.Errorf("the '%s' rack cannot be empty", rackNumber)

	}

	m.inventory[rackNumber] = &models.Rack{
		Number:  rackNumber,
		Product: product,
		Count:   count,
	}

	return nil
}

func (m *InventoryManager) DispenseProduct(rackNumber string) (*models.Product, error) {
	if _, ok := m.inventory[rackNumber]; !ok {
		return nil, fmt.Errorf("the '%s' rack not found", rackNumber)
	}

	rack := m.inventory[rackNumber]
	if rack.Count <= 0 {
		return nil, fmt.Errorf("the '%s' rack is empty", rackNumber)
	}

	rack.Count -= 1

	return &rack.Product, nil
}
