namespace VendingMachine.Vending;

public class InventoryManager
{
    private readonly Dictionary<string, Rack> _racks = new();

    public Rack GetRack(string rackName)
    {
        if (!_racks.TryGetValue(rackName, out var rack))
        {
            throw new ArgumentException($"Rack {rackName} does not exist");
        }

        return rack;
    }

    public bool AddProduct(string rackName, Product product, int count)
    {
        var rack = new Rack
        {
            Number = rackName,
            Product = product,
            Count = count
        };
        _racks.Add(rackName, rack);

        return true;
    }

    public Product DispenseProduct(string rackName)
    {
        if (!_racks.TryGetValue(rackName, out var rack))
        {
            throw new ArgumentException($"Rack {rackName} does not exist");
        }

        if (rack.Count <= 0)
        {
            throw new InvalidOperationException($"Rack {rackName} does not exist");
        }

        rack.Count--;

        return rack.Product;
    }
}
