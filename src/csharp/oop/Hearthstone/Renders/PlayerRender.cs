using Hearthstone.Game.Players;

namespace Hearthstone.Renders;

internal sealed class PlayerRender : RenderBase<Player>
{
    protected override void RenderIternal(Player item)
    {
        if (item.IsCurrent)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"⮞ ");
            Console.Write(item.Name.PadRight(31));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(item.Name.PadRight(33));
        }

        Console.ForegroundColor = item.IsCurrent ? ConsoleColor.Red : ConsoleColor.DarkGray;
        Console.Write($"♥ {item.Health.Current}".PadLeft(6));

        Console.ForegroundColor = item.IsCurrent ? ConsoleColor.Blue : ConsoleColor.DarkGray;
        Console.Write($"◈ {item.Mana.Current}/{item.Mana.Capacity}".PadLeft(8));

        Console.ForegroundColor = item.IsCurrent ? ConsoleColor.Gray : ConsoleColor.DarkGray; ;
        Console.Write($"Deck: {item.Deck.Count}".PadLeft(10));
        Console.WriteLine();

        if (item.IsCurrent)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("".PadLeft(57, '-'));
        }
    }
}
