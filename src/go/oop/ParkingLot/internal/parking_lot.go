package internal

import (
	"errors"
	"time"

	"github.com/dobermanch/dev-quests/parking-lot/internal/fees"
	"github.com/dobermanch/dev-quests/parking-lot/internal/models"

	"github.com/google/uuid"
)

type ParkingLot interface {
	Park(models.Vehicle) (models.Ticket, error)
	Leave(models.Ticket) (models.Ticket, error)
}

type ParkingLotImpl struct {
	manager       ParkingManager
	issuedTickets map[string]*models.Ticket
	calculator    fees.FeeCalculator
}

func New() ParkingLotImpl {
	sizes := map[models.SpotSize]int{
		models.CompactSpot:  10,
		models.NormalSpot:   10,
		models.OversizeSpot: 10,
	}

	var lot = ParkingLotImpl{
		manager:       NewManager(sizes),
		issuedTickets: make(map[string]*models.Ticket),
		calculator:    fees.NewCalculator(nil),
	}

	return lot
}

func (pl *ParkingLotImpl) Park(vehicle models.Vehicle) (models.Ticket, error) {
	spot, err := pl.manager.Park(&vehicle)
	if err != nil {
		return models.Ticket{}, err
	}

	if spot == nil {
		return models.Ticket{}, errors.New("the parking spot not found")
	}

	println("The parking spot %s assigned", spot.Number)

	ticket := &models.Ticket{
		Number:      uuid.New().String(),
		Vehicle:     &vehicle,
		Spot:        spot,
		ParkingTime: time.Now(),
	}

	pl.issuedTickets[ticket.Number] = ticket

	println("The ticket has been issued %s", ticket.Number)

	return *ticket, nil
}

func (pl *ParkingLotImpl) Leave(ticket models.Ticket) (models.Ticket, error) {
	if _, ok := pl.issuedTickets[ticket.Number]; !ok {
		return models.Ticket{}, errors.New("provided ticket is not valid")
	}

	originalTicket := pl.issuedTickets[ticket.Number]
	if originalTicket.LeaveTime != nil {
		return models.Ticket{}, errors.New("provided ticket already processed")
	}

	now := time.Now()
	originalTicket.LeaveTime = &now

	fee, err := pl.calculator.Calculate(*originalTicket)
	if err != nil {
		return models.Ticket{}, err
	}

	originalTicket.Fee = fee

	return *originalTicket, nil
}
