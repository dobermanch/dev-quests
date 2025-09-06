using VendingMachine.Vending.States;

namespace VendingMachine.Vending;

public sealed class VendingMachine
{
    private OrderStateBase _state;

    public VendingMachine(InventoryManager inventoryManager)
    {
        InventoryManager = inventoryManager;
        _state = new IdleState(this);
        _state.Process();
    }

    public InventoryManager InventoryManager { get; }

    public void AddProduct(string rackNumber, Product product, int count)
    {
        if (InventoryManager.AddProduct(rackNumber, product, count))
        {
            Notify($"Added {product.Name} to the {rackNumber} rack");
        }
        else
        {
            Notify($"Failed add {product.Name} to the {rackNumber} rack");
        }
    }

    public void InsertMoney(decimal amount)
    {
        if (_state is not WaitingForMoneyState)
        {
            return;
        }

        _state.Context.Balance = decimal.Add(_state.Context.Balance ?? decimal.Zero, amount);
        _state.Process();
    }

    public void SelectProduct(string code)
    {
        if (_state is not SelectProductState)
        {
            return;
        }

        _state.Context.RackNumber = code;
        _state.Process();
    }

    public void PickupChange()
    {
        if (_state is not ReturnChangeState)
        {
            return;
        }

        _state.Process();
    }

    public void DispenseProduct()
    {
        if (_state is not DispenseProductState)
        {
            return;
        }

        _state.Process();
    }

    internal void Notify(string message)
        => Console.WriteLine(message);

    internal void SetState(OrderStateBase state)
        => _state = state ?? throw new ArgumentNullException(nameof(state));
}
