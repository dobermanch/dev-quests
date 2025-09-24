package internal

type PackageStatus int

const (
	Created PackageStatus = iota
	InLocker
	Delivered
	Expired
)

type Package struct {
	OrderId    string
	Address    string
	User       UserAccount
	Dimensions Dimensions
	Status     PackageStatus
}
