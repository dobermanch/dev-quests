using Hearthstone.Game.Players;

namespace Hearthstone.Renders;

internal sealed class HandRender(IRenderProvider provider) : RenderBase<Hand>
{
    protected override void RenderIternal(Hand item)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();
        Console.WriteLine($"Hand: ");

        for (var i = 0; i < item.Count; i++)
        {
            var card = item[i];
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{i + 1}. ".PadLeft(5));

            provider.Render(card);

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
