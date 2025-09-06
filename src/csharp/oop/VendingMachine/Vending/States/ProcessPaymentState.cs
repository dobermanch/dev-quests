namespace VendingMachine.Vending.States;

public class ProcessPaymentState(OrderContext context) : OrderStateBase(context)
{
    public override void Process()
    {
        if (Context.Rack is null)
        {
            NextState(new SelectProductState(Context));
            return;
        }

        if (Context.Rack.Product.Price <= 0)
        {
            NextState(new WaitingForMoneyState(Context));
            return;
        }

        Context.MissingAmount = decimal.Zero;
        if (Context.Rack.Product.Price > Context.Balance)
        {
            Context.MissingAmount = Context.Rack.Product.Price - Context.Balance;
            NextState(new WaitingForMoneyState(Context));
            return;
        }

        Context.Change = Context.Balance - Context.Rack.Product.Price;
        NextState(new DispenseProductState(Context));
    }

    public override void StateInfo()
        => Notify("Processing payment...");
}
