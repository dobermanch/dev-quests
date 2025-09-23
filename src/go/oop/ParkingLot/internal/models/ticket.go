package models

import "time"

type Ticket struct {
	Number      string
	Vehicle     *Vehicle
	Spot        *ParkingSpot
	ParkingTime time.Time
	LeaveTime   *time.Time
	Fee         float32
}
