using Hearthstone.Game.Cards;
using Hearthstone.Game.Players;

namespace Hearthstone.Tests.Players;

public class HandTests
{
    [Fact]
    public void Should_be_empty_When_created_without_cards()
    {
        var hand = new Hand(Array.Empty<Card>());

        Assert.Empty(hand);
    }

    [Fact]
    public void Should_contains_all_added_cards_When_created()
    {
        var cards = Enumerable.Range(0, 3).Select(it => new DamageCard(it, it)).ToArray();

        var hand = new Hand(cards);

        Assert.Equal(cards, hand);
    }

    [Fact]
    public void Should_contain_added_card_When_new_card_added()
    {
        var card = new DamageCard(1, 1);
        var hand = new Hand(Array.Empty<Card>());

        hand.Add(card);

        Assert.Contains(card, hand);
    }

    [Fact]
    public void Should_be_empty_When_all_cards_removed()
    {
        var card = new DamageCard(1, 1);
        var hand = new Hand(new[] { card });

        hand.Remove(card);

        Assert.True(hand.IsEmpty);
    }
}
