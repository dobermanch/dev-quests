using Hearthstone.Game.Cards;
using Hearthstone.Game.Cards.Features;

namespace Hearthstone.Game.Decks.Providers;

public sealed class DefaultDeckProvider : IDeckProvider
{
    public Deck GetDeck()
    {
        var cards = new List<Card>();

        // 10 cards 1 damage 1 mana
        cards.AddRange(Enumerable.Range(1, 10).Select(it => new DamageCard(1, 1)));

        // 4 cards 2 damage 2 mana
        cards.AddRange(Enumerable.Range(1, 4).Select(it => new DamageCard(2, 2)));

        // 2 cards 3 damage 3 mana
        cards.AddRange(Enumerable.Range(1, 2).Select(it => new DamageCard(3, 3)));

        // 2 cards 4 damage 4 mana
        cards.AddRange(Enumerable.Range(1, 2).Select(it => new DamageCard(4, 4)));

        // 2 cards 5 damage 5 mana
        cards.AddRange(Enumerable.Range(1, 2).Select(it => new DamageCard(5, 5)));

        // 5 cards 1 heal 1 mana
        cards.AddRange(Enumerable.Range(1, 5).Select(it => new HealCard(1, 1)));

        // 2 cards 2 heal 2 mana
        cards.AddRange(Enumerable.Range(1, 2).Select(it => new HealCard(2, 2)));

        // 2 cards 1 damage 1 mana, and draws another card
        cards.AddRange(Enumerable.Range(1, 2).Select(it => new DamageCard(1, 1, new DrawCardFeature())));

        // 1 legendary card 4 damage 5 mana, get 1 extra mana that turn. Output message "You will never defeat me!"
        cards.AddRange(Enumerable.Range(1, 1).Select(it => new DamageCard(5, 4, new LegendaryFeature(), new ExtraManaFeature(1))));

        return new Deck(cards);
    }
}
