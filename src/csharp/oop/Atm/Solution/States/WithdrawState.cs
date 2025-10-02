namespace Atm.Solution.States;

public class WithdrawState(AtmSession session) : AtmState(session)
{
    protected override void StateInfo()
        => Notify("Enter amount to withdraw");

    public override void Process()
    {
        if (Session.WithdrawAmount is null)
        {
            StateInfo();
            return;
        }

        if (Session.WithdrawAmount > Session.Account!.Balance)
        {
            Notify("Not enough money on your account. Enter another amount.");
            return;
        }

        if (Session.Bank.WithdrawCash(Session.Account!, Session.WithdrawAmount!.Value))
        {
            Session.Dispaly.ShowMessage($"Take your money in the cache dispenser: {Session.WithdrawAmount!.Value}");
        }
        else
        {
            Notify("Something went wrong, try again later");
        }

        NextState(new SelectOperationState(Session));
    }
}
