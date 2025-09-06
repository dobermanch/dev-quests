using VendingMachine.Vending;

namespace VendingMachine.Tests;

public class VendingMachineTests
{
    [Fact]
    public void ShouldProcessOrderCorrectly()
    {
        var vendingMachine = new VendingMachine.Vending.VendingMachine(new InventoryManager());

        var pepsi = new Product("1", "Pepsi", 1.5m);
        var cola = new Product("2", "Coca-Cola", 1.6m);
        var paper = new Product("1", "Dr. Paper", 1.4m);

        for (int i = 0; i < 8; i++)
        {
            var row = i < 4 ? 1 : 2;
            vendingMachine.AddProduct($"{row}_{i % 4 + 1}", pepsi, 10);
        }

        for (int i = 0; i < 8; i++)
        {
            var row = i < 4 ? 3 : 4;
            vendingMachine.AddProduct($"{row}_{i % 4 + 1}", cola, 10);
        }

        for (int i = 0; i < 8; i++)
        {
            var row = i < 4 ? 5 : 6;
            vendingMachine.AddProduct($"{row}_{i % 4 + 1}", paper, 10);
        }

        vendingMachine.InsertMoney(1.0m);
        vendingMachine.DispenseProduct(); // wrong command
        vendingMachine.SelectProduct("3_4");
        vendingMachine.InsertMoney(1m);
        vendingMachine.DispenseProduct();
        vendingMachine.PickupChange();
    }
}
