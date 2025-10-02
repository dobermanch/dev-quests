namespace Atm.Solution.States;

public class InsertCardState(AtmSession session) : AtmState(session)
{
    protected override void StateInfo()
        => Notify("Insert card");

    public override void Process()
    {
        if (Session.Card is null)
        {
            StateInfo();
            return;
        }

        if (Session.Bank.ValidateCard(Session.Card))
        {
            NextState(new ValidatePinState(Session));
            return;
        }

        Notify("The card is not valid");
        Session.Atm.EjectCard();
    }
}
