namespace Atm.Solution.States;

public class SelectOperationState(AtmSession session) : AtmState(session)
{
    protected override void StateInfo()
    {
        var operations = Enum.GetNames<OperationType>().Select((it, i) => $"{i + 1}. {it}");
        Notify($"Select operation:\n{string.Join("\n", operations)}");
    }

    public override void Process()
    {
        if (Session.Operation is null)
        {
            StateInfo();
            return;
        }

        AtmState? nextState = Session.Operation switch
        {
            OperationType.Withdraw => new WithdrawState(Session),
            OperationType.Deposit => new DepositState(Session),
            _ => null
        };

        if (nextState is null)
        {
            StateInfo();
            return;
        }

        NextState(nextState);
    }
}
