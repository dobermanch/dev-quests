namespace VendingMachine.Vending.States;

public class SelectProductState(OrderContext context) : OrderStateBase(context)
{
    public override void Process()
    {
        if (Context.RackNumber == null)
        {
            Notify("Please select product code");
            return;
        }

        try
        {
            var rack = Context.VendingMachine.InventoryManager.GetRack(Context.RackNumber);
            if (rack.Count > 0)
            {
                Notify($"Selected rack: {Context.RackNumber}");

                Context.Rack = rack;
                NextState(new ProcessPaymentState(Context), true);
                return;
            }

            Notify($"Selected rack {Context.RackNumber} is empty");
        }
        catch (ArgumentException ex)
        {
            Notify(ex.Message);
        }

        Notify("Please select product code");
    }

    public override void StateInfo()
        => Notify("Please select product code");
}
