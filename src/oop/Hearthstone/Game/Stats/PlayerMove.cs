using Hearthstone.Game.Cards;
using Hearthstone.Game.Players;

namespace Hearthstone.Game.Stats;

public abstract record PlayerMove(int Round, Player Player, Card PlayedCard);
