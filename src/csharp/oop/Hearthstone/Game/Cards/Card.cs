using Hearthstone.Game.Cards.Features;

namespace Hearthstone.Game.Cards;

public abstract record Card(int Cost, int Value, IList<ICardFeature>? Features);