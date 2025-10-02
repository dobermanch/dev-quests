namespace Atm.Solution.Banking;

public class Bank
{
    private readonly Dictionary<string, UserAccounts> _accountsByCardNumber;
    private readonly Dictionary<string, UserAccounts> _accountsByNumber;

    public Bank(IList<UserAccounts> accounts)
    {
        _accountsByCardNumber = accounts.ToDictionary(it => it.CardNumber, it => it);
        _accountsByNumber = accounts
            .SelectMany(it => it.Accounts, (user, account) => (account.AccountNumber, user))
            .ToDictionary(it => it.AccountNumber, it => it.user);
    }

    public IReadOnlyCollection<Account> GetAccounts(Card card)
        => _accountsByCardNumber.GetValueOrDefault(card.CardNumber)?.Accounts ?? [];

    public bool ValidateCard(Card card)
        => _accountsByCardNumber.TryGetValue(card.CardNumber, out var account)
           && account.UserName.Equals(card.HolderName, StringComparison.InvariantCulture)
           && account.Accounts.Count > 0;

    public bool ValidateCardPin(Card card, string pin)
        => _accountsByCardNumber.TryGetValue(card.CardNumber, out var account)
           && account.CardPinHash == pin.GetHashCode().ToString();

    public bool WithdrawCash(Account account, decimal amount)
    {
        if (account.Balance > amount)
        {
            var userAccounts = _accountsByNumber[account.AccountNumber];
            userAccounts.Accounts.Remove(account);
            userAccounts.Accounts.Add(account with { Balance = account.Balance - amount });
            return true;
        }

        return false;
    }

    public bool DepositCash(Account account, decimal amount)
    {
        var userAccounts = _accountsByNumber[account.AccountNumber];
        userAccounts.Accounts.Remove(account);
        userAccounts.Accounts.Add(account with { Balance = account.Balance + amount });
        return true;
    }
}
