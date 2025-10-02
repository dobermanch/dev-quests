namespace Atm.Solution;

public class Dispaly(Action<string>? display = null)
{
    private readonly Action<string> _display = display ?? Console.WriteLine;

    public void ShowMessage(string message)
        => _display(message);
}
