package fees

import (
	"github.com/dobermanch/dev-quests/parking-lot/internal/models"
)

type HourlyRateStrategy struct{}

var (
	peakHourRate float32 = 1.5
)

func (s HourlyRateStrategy) Calculate(ticket models.Ticket, currentRate float32) float32 {
	hour := ticket.ParkingTime.Hour()
	if (hour >= 7 && hour <= 10) || (hour >= 16 && hour <= 19) {
		return currentRate * peakHourRate
	}

	return currentRate
}
