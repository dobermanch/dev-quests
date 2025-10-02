using Atm.Solution.Banking;
using Atm.Solution.States;

namespace Atm.Solution;

public sealed class AtmSystem
{
    private AtmState _state;
    private readonly Bank _bank;
    private readonly Dispaly _display;

    public AtmSystem(Bank bank, Dispaly display)
    {
        _bank = bank;
        _display = display;

        _state = new IdleState(this, bank, display);
        _state.Process();
    }

    internal void SetState(AtmState state)
        => _state = state;

    public void InsertCard(Card card)
    {
        if (_state is not InsertCardState)
        {
            return;
        }

        _display.ShowMessage($"Insert card: {card.CardNumber}");
        _state.Session.Card = card;
        _state.Process();
    }

    public void EnterPin(string pin)
    {
        if (_state is not ValidatePinState)
        {
            return;
        }

        _display.ShowMessage($"Entered pin: {pin}");
        _state.Session.Pin = pin;
        _state.Process();
    }

    public void SelectAccount(AccountType accountType)
    {
        if (_state is not SelectAccountState)
        {
            return;
        }

        _display.ShowMessage($"Selected account: {accountType}");
        _state.Session.AccountType = accountType;
        _state.Process();
    }

    public void SelectOperation(OperationType operationType)
    {
        if (_state is not SelectOperationState)
        {
            return;
        }

        _display.ShowMessage($"Selected operation: {operationType}");
        _state.Session.Operation = operationType;
        _state.Process();
    }

    public void DepositCash(decimal amount)
    {
        if (_state is not DepositState)
        {
            return;
        }

        _display.ShowMessage($"Insert cash: {amount}");
        _state.Session.DepositAmount = amount;
        _state.Process();
    }

    public void WithdrawCash(decimal amount)
    {
        if (_state is not WithdrawState)
        {
            return;
        }

        _display.ShowMessage($"Requested amount of cash: {amount}");
        _state.Session.WithdrawAmount = amount;
        _state.Process();
    }

    public Card? EjectCard()
    {
        if (_state is InsertCardState or IdleState)
        {
            return null;
        }

        var card = _state.Session.Card!;
        _display.ShowMessage("Take you card.");
        _state = new IdleState(this, _bank, _display);
        _state.Process();

        return card;
    }
}
