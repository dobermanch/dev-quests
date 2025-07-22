using Hearthstone.Game.Cards;
using Hearthstone.Game.Cards.Features;

namespace Hearthstone.Renders;

internal sealed class CardRender : RenderBase<Card>
{
    protected override void RenderIternal(Card card)
    {
        if (card is HealCard)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("♥ ");
            Console.Write($"Mana: {card.Cost} Heal: {card.Value}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("⤱ ");
            Console.Write($"Mana: {card.Cost} Damage: {card.Value}");
        }

        if ((card.Features?.Any()) != true)
        {
            return;
        }

        Console.Write(" (");
        for (var j = 0; j < card.Features.Count; j++)
        {
            switch (card.Features[j])
            {
                case LegendaryFeature:
                    Console.Write("Legendary");
                    break;
                case ExtraManaFeature:
                    Console.Write("Extra Mana");
                    break;
                case DrawCardFeature:
                    Console.Write("Draw Card");
                    break;
            }

            if (j < card.Features.Count - 1)
            {
                Console.Write(", ");
            }
        }

        Console.Write(")");
    }
}
