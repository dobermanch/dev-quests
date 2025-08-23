using Hearthstone.Game.Cards;
using Hearthstone.Game.Decks;

namespace Hearthstone.Game.Players;

public interface IPlayer
{
    Deck Deck { get; }

    Hand Hand { get; }

    Health Health { get; }

    bool IsCurrent { get; }

    ManaCrystals Mana { get; }

    string Name { get; }

    Task EndTurnAsync(CancellationToken cancellation);

    Task PlayCardAsync(Card card, CancellationToken cancellation);
}