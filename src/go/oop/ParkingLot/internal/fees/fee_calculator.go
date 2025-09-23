package fees

import (
	"errors"

	"github.com/dobermanch/dev-quests/parking-lot/internal/models"
)

type FeeCalculator interface {
	Calculate(models.Ticket) (float32, error)
}

type FeeCalculatorImpl struct {
	strategies []RateStrategy
}

func NewCalculator(strategies []RateStrategy) FeeCalculator {
	if len(strategies) <= 0 {
		strategies = []RateStrategy{
			BaseRateStrategy{},
			HourlyRateStrategy{},
		}
	}

	calculator := &FeeCalculatorImpl{
		strategies: strategies,
	}

	return calculator
}

func (c *FeeCalculatorImpl) Calculate(ticket models.Ticket) (float32, error) {
	if len(c.strategies) <= 0 {
		return 0, errors.New("calculator strategies are not defined")
	}

	if ticket.LeaveTime == nil {
		return 0, errors.New("the ticket is not valid, the end date is not set")
	}

	var rate float32 = 0.0
	for _, strategy := range c.strategies {
		rate = strategy.Calculate(ticket, rate)
	}

	duration := ticket.LeaveTime.Sub(ticket.ParkingTime)

	var fee float32 = rate
	if duration.Hours() >= 1 {
		fee = float32(duration.Hours()) * rate
	}

	return fee, nil
}
