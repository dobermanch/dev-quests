using Atm.Solution.Banking;

namespace Atm.Solution.States;

public class SelectAccountState(AtmSession session) : AtmState(session)
{
    protected override void StateInfo()
    {
        IReadOnlyCollection<Account> accounts = Session.Bank.GetAccounts(Session.Card!);
        Notify($"Select account type:\n{string.Join("\n", accounts.Select((x, i) => $"{i + 1}. {x.AccountType}"))}");
    }

    public override void Process()
    {
        if (Session.AccountType is null)
        {
            StateInfo();
            return;
        }

        Session.Account = Session.Bank
            .GetAccounts(Session.Card!)
            .First(it => it.AccountType == Session.AccountType);

        Notify($"Current balance: {Session.Account!.Balance}");

        NextState(new SelectOperationState(Session));
    }
}
