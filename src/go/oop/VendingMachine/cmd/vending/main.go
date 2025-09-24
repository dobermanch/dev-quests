package main

import (
	"fmt"

	"github.com/dobermanch/dev-quests/vending-machine/internal"
	"github.com/dobermanch/dev-quests/vending-machine/internal/models"
)

func main() {
	machine := internal.New()

	pepsi := models.Product{
		Code:  "1",
		Name:  "Pepsi",
		Price: 1.5,
	}

	cola := models.Product{
		Code:  "2",
		Name:  "Coca-Cola",
		Price: 1.6,
	}

	paper := models.Product{
		Code:  "3",
		Name:  "Dr. Paper",
		Price: 1.4,
	}

	for i := 0; i <= 8; i++ {
		var code string = fmt.Sprintf("%d", i%4+1)
		if i < 4 {
			code = "1_" + code
		} else {
			code = "2_" + code
		}
		machine.AddProduct(code, pepsi, 10)
	}

	for i := 0; i <= 8; i++ {
		var code string = fmt.Sprintf("%d", i%4+1)
		if i < 4 {
			code = "3_" + code
		} else {
			code = "4_" + code
		}
		machine.AddProduct(code, cola, 10)
	}

	for i := 0; i <= 8; i++ {
		var code string = fmt.Sprintf("%d", i%4+1)
		if i < 4 {
			code = "5_" + code
		} else {
			code = "6_" + code
		}
		machine.AddProduct(code, paper, 10)
	}

	machine.InsertMoney(1.0)
	machine.DispenseProduct() // wrong command
	machine.SelectProduct("3_4")
	machine.InsertMoney(1)
	machine.DispenseProduct()
	machine.PickupChange()
}
