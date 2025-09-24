package notifications

import "fmt"

type Notification interface {
	Notify(message any)
}

type Display struct{}

func (d *Display) Notify(message any) {
	fmt.Println(message)
}
