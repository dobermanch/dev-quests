namespace Atm.Solution.States;

public class DepositState(AtmSession session) : AtmState(session)
{
    protected override void StateInfo()
        => Notify("Put the cache into the deposit box");

    public override void Process()
    {
        if (Session.DepositAmount is null)
        {
            StateInfo();
            return;
        }

        if (Session.Bank.DepositCash(Session.Account!, Session.DepositAmount!.Value))
        {
            Session.Account = Session.Bank.GetAccounts(Session.Card!)
                .First(it => it.AccountType == Session.AccountType);

            Notify($"Your new balance: {Session.Account.Balance}");
        }
        else
        {
            Notify("Something went wrong, try again later");
        }

        NextState(new SelectOperationState(Session));
    }
}
