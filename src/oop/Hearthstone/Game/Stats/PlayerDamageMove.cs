using Hearthstone.Game.Cards;
using Hearthstone.Game.Players;

namespace Hearthstone.Game.Stats;

public record PlayerDamageMove(int Round, Player Player, Card PlayedCard, Player targetPlayer, int healthBefore, int healthAfter)
    : PlayerMove(Round, Player, PlayedCard);
