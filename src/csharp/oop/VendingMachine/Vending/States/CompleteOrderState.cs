namespace VendingMachine.Vending.States;

public class CompleteOrderState(OrderContext context) : OrderStateBase(context)
{
    public override void Process()
    {
        NextState(new IdleState(Context.VendingMachine), true);
    }

    public override void StateInfo()
    {
        Notify("Thank you for purchase");
    }
}
