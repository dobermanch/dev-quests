using Atm.Solution.Banking;

namespace Atm.Solution.States;

public sealed class IdleState(AtmSystem atm, Bank bank, Dispaly display)
    : AtmState(new AtmSession(atm, bank, display))
{
    public override void Process()
        => NextState(new InsertCardState(Session), false);
}
