namespace VendingMachine.Vending;

public record Rack
{
    public required string Number { get; init; }
    public required Product Product { get; init; }
    public int Count { get; set; }
}
