using Hearthstone.Game.Cards.Features;

namespace Hearthstone.Game.Cards;

public record DamageCard : Card
{
    public DamageCard(int cost, int damage, params ICardFeature[] features) 
        : base(cost, damage, features) { }
}
