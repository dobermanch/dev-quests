using Hearthstone.Game.Cards;

namespace Hearthstone.Game.Decks.Shuffle;

public sealed class DefaultCardShuffle : ICardShuffle
{
    private readonly Random _random = new(DateTime.UtcNow.Microsecond);

    public void Shuffle(IList<Card> cards)
    {
        int currentIndex = cards.Count();
        while (currentIndex-- > 1)
        {
            int swapIndex = _random.Next(currentIndex + 1);
            (cards[currentIndex], cards[swapIndex]) = (cards[swapIndex], cards[currentIndex]);
        }
    }
}
