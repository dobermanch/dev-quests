package internal

import "time"

type PriceCalculator struct {
}

var (
	expirationRate float32 = 1.1
	smallRate      float32 = 1
	mediumRate     float32 = 2
	largeRate      float32 = 3
)

func (c *PriceCalculator) Calculate(locker *Locker) float32 {
	freeDate := locker.AssignDate.AddDate(0, 0, locker.pkg.User.Policy.FreeDaysPeriod)
	if time.Now().After(freeDate) {
		return 0
	}

	switch locker.Size.Type {
	case SmallLocker:
		return smallRate
	case MediumLocker:
		return mediumRate
	case LargeLocker:
		return largeRate
	}

	return mediumRate
}

func (c *PriceCalculator) CalculateExpirationPrice(locker *Locker) float32 {
	price := c.Calculate(locker)
	return price * expirationRate
}
