using Hearthstone.Game.Notifications;
using System.Collections.ObjectModel;

namespace Hearthstone.Renders;

internal sealed class NotificationRender : RenderBase<ReadOnlyCollection<IGameNotification>>
{
    protected override void RenderIternal(ReadOnlyCollection<IGameNotification> notifications)
    {
        if ((notifications?.Any()) != true)
        {
            return;
        }

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();
        Console.WriteLine("Notifications:");

        foreach (var notification in notifications)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - ");

            switch (notification)
            {
                case LegendaryCardNotification:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("You will never defeat me!");
                    break;
                case NoManaNotification:
                    Console.Write("You do not have enough mana to play your cards.");
                    break;
                case NotEnoughManaNotification:
                    Console.Write("You do not have enough mana to play this card.");
                    break;
                case EmptyHandNotification:
                    Console.Write("You do not have cards in your hand.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}