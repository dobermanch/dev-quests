namespace VendingMachine.Vending;

public record OrderContext(VendingMachine VendingMachine)
{
    public decimal? Balance { get; set; }
    public decimal? MissingAmount { get; set; }
    public decimal? Change { get; set; }
    public string? RackNumber { get; set; }
    public Rack? Rack { get; set; }
}
