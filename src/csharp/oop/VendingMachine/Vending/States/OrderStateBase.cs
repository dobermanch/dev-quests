namespace VendingMachine.Vending.States;

public abstract class OrderStateBase(OrderContext context)
{
    public OrderContext Context { get; } = context;

    public abstract void Process();

    public virtual void StateInfo() { }

    protected void NextState(OrderStateBase state, bool execute = false)
    {
        Context.VendingMachine.SetState(state);
        state.StateInfo();
        if (execute)
        {
            state.Process();
        }
    }

    protected void Notify(string message)
        => Context.VendingMachine.Notify(message);
}
