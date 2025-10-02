namespace Atm.Solution.Banking;

public record UserAccounts(
    string UserName,
    List<Account> Accounts,
    string CardNumber,
    string CardPinHash
);
