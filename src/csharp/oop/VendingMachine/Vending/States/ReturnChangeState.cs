namespace VendingMachine.Vending.States;

public class ReturnChangeState(OrderContext context) : OrderStateBase(context)
{
    public override void Process()
    {
        Context.Change = Decimal.Zero;
        NextState(new CompleteOrderState(Context), true);
    }

    public override void StateInfo()
    {
        if (Context.Change <= Decimal.Zero)
        {
            NextState(new CompleteOrderState(Context), true);
            return;
        }

        Notify($"Please peak up the change: {Context.Change}");
    }
}
