using Atm.Solution.Banking;

namespace Atm.Solution.States;

public record AtmSession(AtmSystem Atm, Bank Bank, Dispaly Dispaly)
{
    public Card? Card { get; set; }
    public string? Pin { get; set; }
    public AccountType? AccountType { get; set; }
    public Account? Account { get; set; }
    public int PinAttempt { get; set; }
    public OperationType? Operation { get; set; }
    public decimal? WithdrawAmount { get; set; }
    public decimal? DepositAmount { get; set; }
}
