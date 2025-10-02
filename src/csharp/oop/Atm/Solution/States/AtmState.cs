namespace Atm.Solution.States;

public abstract class AtmState(AtmSession session)
{
    public AtmSession Session { get; } = session;

    public abstract void Process();

    protected void NextState(AtmState state, bool execute = false)
    {
        Session.Atm.SetState(state);
        state.StateInfo();
        if (execute)
        {
            state.Process();
        }
    }

    protected virtual void StateInfo() { }

    protected void Notify(string message)
        => Session.Dispaly.ShowMessage(message);
}
