package internal

import (
	"strconv"

	"github.com/dobermanch/dev-quests/parking-lot/internal/models"
)

type ParkingManager interface {
	Park(*models.Vehicle) (*models.ParkingSpot, error)
	Vacate(*models.ParkingSpot)
}

type ParkingManagerImpl struct {
	bySize map[models.SpotSize][]*models.ParkingSpot
}

func NewManager(sizes map[models.SpotSize]int) ParkingManager {
	manager := &ParkingManagerImpl{}
	manager.bySize = make(map[models.SpotSize][]*models.ParkingSpot)

	for size, count := range sizes {
		manager.bySize[size] = []*models.ParkingSpot{}

		for i := 1; i <= count; i++ {
			manager.bySize[size] = append(manager.bySize[size], &models.ParkingSpot{Number: "Space " + strconv.Itoa(i), Size: size})
		}
	}

	return manager
}

func (pm *ParkingManagerImpl) Park(vehicle *models.Vehicle) (*models.ParkingSpot, error) {
	spotSize := vehicleSizeToSpotSize(vehicle.Size)

	sizes := spotSize.GetAllSuitableSpots()

	var foundSpot *models.ParkingSpot
	for _, size := range sizes {

		if _, ok := pm.bySize[size]; !ok {
			continue
		}

		for _, spot := range pm.bySize[size] {
			if spot.IsAvailable() {
				continue
			}

			foundSpot = spot
			spot.Park(vehicle)
			break
		}

		if foundSpot != nil {
			break
		}
	}

	return foundSpot, nil
}

func (pm *ParkingManagerImpl) Vacate(spot *models.ParkingSpot) {
	spot.Vacate()
}

func vehicleSizeToSpotSize(size models.VehicleSize) models.SpotSize {
	switch size {
	case models.SmallVehicle:
		return models.CompactSpot
	case models.MediumVehicle:
		return models.NormalSpot
	case models.LargeVehicle:
		return models.OversizeSpot
	}

	return models.NormalSpot
}
