using Hearthstone.Game.Cards;
using Hearthstone.Game.Players;

namespace Hearthstone.Game.Stats;

public record PlayerHealMove(int Round, Player Player, Card PlayedCard, int healthBefore, int healthAfter) 
    : PlayerMove(Round, Player, PlayedCard);
