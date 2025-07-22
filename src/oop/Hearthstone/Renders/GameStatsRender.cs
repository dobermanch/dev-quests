using Hearthstone.Game.Players;
using Hearthstone.Game.Stats;

namespace Hearthstone.Renders;

internal sealed class GameStatsRender(IRenderProvider provider) : RenderBase<GameStats>
{
    protected override void RenderIternal(GameStats stats)
    {
        RenderHeader(stats);

        RenderWinnerName(stats);

        RenderDivider();

        foreach (var player in stats.Players)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine(player.Name);

            RenderDivider();

            RenderDeck(player);
            RenderRounds(stats.Moves.Where(it => it.Player == player).ToArray());
        }
    }

    private static void RenderDivider()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("".PadLeft(57, '-'));
    }

    private static void RenderWinnerName(GameStats stats)
    {
        if (stats.Winner == null)
        {
            return;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine();
        Console.Write($"WINNER: {stats.Winner.Name}");
        Console.WriteLine($"♥ {stats.Winner.Health.Current}".PadLeft(6));
    }

    private static void RenderHeader(GameStats stats)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("GAME STATS");
        Console.WriteLine();
        Console.WriteLine();

        Console.Write($"Duration: {stats.GameDuration:hh':'mm':'ss}");
        Console.WriteLine();
    }

    private void RenderDeck(Player player)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write($"Cards left in deck: {player.Deck.Count}".PadLeft(10));
        Console.WriteLine();

        foreach (var card in player.Deck)
        {
            Console.Write("".PadLeft(3));
            provider.Render(card);

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private void RenderRounds(IList<PlayerMove> moves)
    {
        if (moves.Count <= 0)
        {
            return;
        }

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Rounds:");

        foreach (var move in moves.OrderBy(it => it.Round).GroupBy(it => it.Round))
        {
            Console.Write($"{move.Key}. ".PadLeft(5));

            var rounds = move.ToArray();
            for (var i = 0; i < rounds.Length; i++)
            {
                if (rounds[i] is PlayerHealMove healMove)
                {
                    Console.Write("heal".PadRight(7));
                    Console.Write($"{healMove.PlayedCard.Value}".PadLeft(2));
                    Console.Write($": ♥ {healMove.healthBefore} => {healMove.healthAfter}");
                }
                else if (rounds[i] is PlayerDamageMove damageMove)
                {
                    Console.Write("demage ");
                    Console.Write($"{damageMove.PlayedCard.Value}".PadLeft(2));
                    Console.Write($": {damageMove.targetPlayer.Name} ♥ {damageMove.healthBefore} => {damageMove.healthAfter}");
                }

                if (i < rounds.Length - 1)
                {
                    Console.WriteLine();
                    Console.Write("".PadLeft(5));
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
