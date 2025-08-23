using Hearthstone.Game.Cards;

namespace Hearthstone.Game.Decks.Shuffle;

public interface ICardShuffle
{
    void Shuffle(IList<Card> cards);
}

