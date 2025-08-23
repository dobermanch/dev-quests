using Hearthstone.Game.Cards.Features;

namespace Hearthstone.Game.Cards;

public record HealCard : Card
{
    public HealCard(int cost, int heal, params ICardFeature[] features)
        : base(cost, heal, features) { }
}
