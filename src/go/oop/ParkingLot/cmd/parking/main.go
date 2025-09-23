package main

import (
	"fmt"

	"github.com/dobermanch/dev-quests/parking-lot/internal"
	"github.com/dobermanch/dev-quests/parking-lot/internal/models"
)

func main() {
	lot := internal.New()

	ticket, err := lot.Park(models.Vehicle{
		Size:    models.MediumVehicle,
		License: "123ABC",
	})

	fmt.Printf("Parked Ticket: %+v\n", ticket)

	if err != nil {
		fmt.Print(err)
		return
	}

	ticket, err = lot.Leave(ticket)
	if err != nil {
		fmt.Print(err)
		return
	}

	fmt.Printf("Leave Ticket: %+v\n", ticket)
}
