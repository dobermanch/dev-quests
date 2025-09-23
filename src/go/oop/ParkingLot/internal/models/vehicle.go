package models

type Vehicle struct {
	Size    VehicleSize
	License string
}

type VehicleSize int

const (
	SmallVehicle VehicleSize = iota
	MediumVehicle
	LargeVehicle
)
