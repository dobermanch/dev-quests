using Hearthstone.Game.Cards;
using System.Collections;
using Hearthstone.Game.Decks.Shuffle;

namespace Hearthstone.Game.Decks;

public class Deck : IEnumerable<Card>
{
    private readonly List<Card> _cards;

    public Deck(IEnumerable<Card> cards)
    {
        if (cards is null)
        {
            throw new ArgumentNullException(nameof(cards));
        }

        _cards = cards.ToList();
    }

    public bool IsEmpty => _cards.Count == 0;

    public int Count => _cards.Count;

    public void Shuffle(ICardShuffle shuffleStrategy)
    {
        if (shuffleStrategy is null)
        {
            throw new ArgumentNullException(nameof(shuffleStrategy));
        }

        shuffleStrategy.Shuffle(_cards);
    }

    public Card? TakeCard() 
        => IsEmpty ? null : TakeCards(1).First();

    public IList<Card> TakeCards(int count)
    {
        var cards = _cards.Take(count).ToArray();
        foreach (var card in cards)
        {
            _cards.Remove(card);
        }

        return cards;
    }

    public IEnumerator<Card> GetEnumerator() => _cards.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
