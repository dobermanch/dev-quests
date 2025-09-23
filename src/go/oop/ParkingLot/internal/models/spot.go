package models

type ParkingSpot struct {
	Number  string
	Size    SpotSize
	vehicle *Vehicle
}

type SpotSize int

const (
	CompactSpot SpotSize = iota
	NormalSpot
	OversizeSpot
)

var (
	sizes = []SpotSize{CompactSpot, NormalSpot, OversizeSpot}
)

func (ps *ParkingSpot) IsAvailable() bool {
	return ps.vehicle != nil
}

func (ps *ParkingSpot) Park(vehicle *Vehicle) {
	ps.vehicle = vehicle
}

func (ps *ParkingSpot) Vacate() {
	ps.vehicle = nil
}

func (s SpotSize) GetAllSuitableSpots() []SpotSize {
	result := []SpotSize{}
	for _, size := range sizes {
		if size >= s {
			result = append(result, size)
		}
	}

	return result
}
