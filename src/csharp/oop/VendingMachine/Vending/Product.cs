namespace VendingMachine.Vending;

public readonly record struct Product(
    string Code,
    string Name,
    decimal Price
);
