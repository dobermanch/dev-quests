using Hearthstone.Game.Cards;

namespace Hearthstone.Game.Players;

public class Hand(IEnumerable<Card> cards) : List<Card>(cards)
{
    public bool IsEmpty => Count <= 0;
}
