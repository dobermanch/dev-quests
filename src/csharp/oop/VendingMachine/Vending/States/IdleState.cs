namespace VendingMachine.Vending.States;

public class IdleState(VendingMachine vendingMachine)
    : OrderStateBase(new OrderContext(vendingMachine))
{
    public override void Process() => NextState(new WaitingForMoneyState(Context));
}
