package fees

import (
	"github.com/dobermanch/dev-quests/parking-lot/internal/models"
)

type BaseRateStrategy struct{}

var (
	compactRate  float32 = 1.0
	normalRate   float32 = 1.5
	oversizeRate float32 = 2.0
)

func (s BaseRateStrategy) Calculate(ticket models.Ticket, currentRate float32) float32 {
	switch ticket.Spot.Size {
	case models.CompactSpot:
		return compactRate
	case models.NormalSpot:
		return normalRate
	case models.OversizeSpot:
		return oversizeRate
	}

	return normalRate
}
