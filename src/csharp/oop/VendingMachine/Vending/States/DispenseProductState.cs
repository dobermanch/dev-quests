namespace VendingMachine.Vending.States;

public class DispenseProductState(OrderContext context) : OrderStateBase(context)
{
    public override void Process()
    {
        try
        {
            Context.VendingMachine.InventoryManager.DispenseProduct(Context.Rack!.Number);
            NextState(new ReturnChangeState(Context));
        }
        catch (InvalidOperationException ex)
        {
            Notify(ex.Message);
            NextState(new SelectProductState(Context));
        }
    }

    public override void StateInfo()
        => Notify($"Peak up the product: {Context.Rack!.Product.Name}");
}
