package internal

type UserAccount struct {
	Id            string
	Name          string
	Policy        LockerPolicy
	BillingAmount float32
}
