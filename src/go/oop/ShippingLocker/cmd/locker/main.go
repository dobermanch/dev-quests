package main

import (
	"fmt"

	"github.com/dobermanch/dev-quests/locker/internal"
)

func main() {
	policy := internal.LockerPolicy{
		FreeDaysPeriod: 10,
		MaxDaysPeriod:  15,
	}

	account := internal.UserAccount{
		Id:     "1",
		Name:   "John Doe",
		Policy: policy,
	}

	pkg := internal.Package{
		OrderId: "Order 1",
		Address: "Addr 1",
		User:    account,
		Dimensions: internal.Dimensions{
			Width:  6,
			Height: 10,
			Depth:  10,
		},
		Status: internal.Created,
	}

	small := internal.LockerSize{
		Type: internal.SmallLocker,
		Dimensions: internal.Dimensions{
			Width:  5,
			Height: 10,
			Depth:  10,
		},
	}

	medium := internal.LockerSize{
		Type: internal.MediumLocker,
		Dimensions: internal.Dimensions{
			Width:  10,
			Height: 20,
			Depth:  20,
		},
	}

	large := internal.LockerSize{
		Type: internal.LargeLocker,
		Dimensions: internal.Dimensions{
			Width:  20,
			Height: 30,
			Depth:  30,
		},
	}

	system := internal.System("Addr 1", map[internal.LockerSize]int{small: 20, medium: 10, large: 5})

	system.AddPackage(&pkg)

	var code string
	fmt.Print("\nEnter access code: ")
	fmt.Scanln(&code)

	_, err := system.GetPackage(code)
	for err != nil {
		fmt.Println(err)
		fmt.Print("\nEnter access code: ")
		fmt.Scanln(&code)
		_, err = system.GetPackage(code)
	}
}
