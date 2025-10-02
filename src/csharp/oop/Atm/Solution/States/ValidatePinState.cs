namespace Atm.Solution.States;

public class ValidatePinState(AtmSession session) : AtmState(session)
{
    private const int MaxAttempts = 3;

    protected override void StateInfo()
        => Notify("Enter card PIN");

    public override void Process()
    {
        if (Session.Pin is null)
        {
            StateInfo();
            return;
        }

        if (Session.Bank.ValidateCardPin(Session.Card!, Session.Pin!))
        {
            NextState(new SelectAccountState(Session));
            return;
        }

        Session.PinAttempt += 1;
        if (Session.PinAttempt >= MaxAttempts)
        {
            Notify("Maximum number of attempts reached");
            Session.Atm.EjectCard();
            return;
        }

        Notify("Pin is not valid, try again.");
    }
}
