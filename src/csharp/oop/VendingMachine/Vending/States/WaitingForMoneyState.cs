namespace VendingMachine.Vending.States;

public class WaitingForMoneyState(OrderContext context)
    : OrderStateBase(context)
{
    public override void Process()
    {
        if (Context.Balance <= decimal.Zero)
        {
            Notify("Please insert money");
            return;
        }

        Notify($"Current balance is {Context.Balance}");
        if (Context.MissingAmount.HasValue)
        {
            NextState(new ProcessPaymentState(Context), true);
        }
        else
        {
            NextState(new SelectProductState(Context));
        }
    }

    public override void StateInfo()
    {
        Notify(Context.MissingAmount.HasValue
            ? $"Not enough money, please add '{Context.MissingAmount}'"
            : "Please insert money");

        base.StateInfo();
    }
}
