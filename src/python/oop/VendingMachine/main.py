from vending import *

def main():
    vending_machine = VendingMachine()

    pepsi = Product("1", "Pepsi", 1.5)
    cola = Product("2", "Coca-Cola", 1.6)
    paper = Product("1", "Dr. Paper", 1.4)

    for i in range(0, 8):
        vending_machine.add_product(f"{1 if i < 4 else 2}_{i % 4 + 1}", pepsi, 10)

    for i in range(0, 8):
        vending_machine.add_product(f"{3 if i < 4 else 4}_{i % 4 + 1}", cola, 10)

    for i in range(0, 8):
        vending_machine.add_product(f"{5 if i < 4 else 6}_{i % 4 + 1}", paper, 10)

    vending_machine.insert_money(1.0)
    vending_machine.dispense_product() # wrong command
    vending_machine.select_product("3_4")
    vending_machine.insert_money(1)
    vending_machine.dispense_product()
    vending_machine.pickup_change()

if __name__ == "__main__":
    main()
