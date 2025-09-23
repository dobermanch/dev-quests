package fees

import (
	"github.com/dobermanch/dev-quests/parking-lot/internal/models"
)

type RateStrategy interface {
	Calculate(models.Ticket, float32) float32
}
