using Atm.Solution;
using Atm.Solution.Banking;
using Atm.Solution.States;
using Xunit.Abstractions;

namespace Atm.Tests;

public class AtmTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void Test()
    {
        var atm = new AtmSystem(
            new Bank([
                new UserAccounts(
                    "John Doe",
                    [
                        new("123456", AccountType.Checking, 198m),
                        new("654321", AccountType.Saving, 100m)
                    ],
                    "123-456",
                    "1234".GetHashCode().ToString()
                )
            ]),
            new Dispaly(testOutputHelper.WriteLine)
        );

        atm.InsertCard(new Card("John Doe", "123-456"));
        atm.EnterPin("1234");
        atm.SelectAccount(AccountType.Checking);
        atm.SelectOperation(OperationType.Deposit);
        atm.DepositCash(100);
        atm.SelectOperation(OperationType.Withdraw);
        atm.WithdrawCash(50);
        atm.EjectCard();
    }
}
