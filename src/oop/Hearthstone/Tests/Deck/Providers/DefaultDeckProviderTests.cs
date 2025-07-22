using Hearthstone.Game.Cards;
using Hearthstone.Game.Cards.Features;
using Hearthstone.Game.Decks.Providers;

namespace Hearthstone.Tests.Deck.Providers;

public class DefaultDeckProviderTests
{
    [Theory]
    [InlineData(typeof(DamageCard), 1, 1, false, 10)]
    [InlineData(typeof(DamageCard), 2, 2, false, 4)]
    [InlineData(typeof(DamageCard), 3, 3, false, 2)]
    [InlineData(typeof(DamageCard), 4, 4, false, 2)]
    [InlineData(typeof(DamageCard), 5, 5, false, 2)]
    [InlineData(typeof(HealCard), 1, 1, false, 5)]
    [InlineData(typeof(HealCard), 2, 2, false, 2)]
    [InlineData(typeof(DamageCard), 1, 1, true, 2)]
    [InlineData(typeof(DamageCard), 5, 4, true, 1)]
    public void GetDeck_Should_return_correct_cards_When_new_deck_requested(Type cardType, int cost, int value, bool withFeature, int expected)
    {
        var deck = new DefaultDeckProvider().GetDeck();

        var cards =  (
                from it in deck
                where 
                    it.GetType() == cardType
                    && it.Cost == cost
                    && it.Value == value
                    && (
                        !withFeature && it.Features?.Any() == false 
                        || withFeature && it.Features!.Any()
                       )
                select it
            ).ToArray();

        Assert.Equal(expected, cards.Length);
    }

    [Theory]
    [InlineData(typeof(DamageCard), new[] { typeof(DrawCardFeature) }, 2)]
    [InlineData(typeof(DamageCard), new[] { typeof(LegendaryFeature), typeof(ExtraManaFeature) }, 1)]
    public void GetDeck_Should_return_correct_cards_with_features_When_new_deck_requested(Type cardType, Type[] features, int expected)
    {
        var deck = new DefaultDeckProvider().GetDeck();

        var cards = (
                from it in deck
                where
                    it.GetType() == cardType
                    && features.All(f1 => it.Features!.Any(f2 => f2.GetType() == f1))
                select it
            ).ToArray();

        Assert.Equal(expected, cards.Length);
    }
}
