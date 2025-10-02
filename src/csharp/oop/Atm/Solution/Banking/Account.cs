namespace Atm.Solution.Banking;

public record Account(
    string AccountNumber,
    AccountType AccountType,
    decimal Balance
);
