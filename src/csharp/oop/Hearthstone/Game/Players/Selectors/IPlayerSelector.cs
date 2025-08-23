namespace Hearthstone.Game.Players.Selectors;

public interface IPlayerSelector
{
    Player Select(IList<Player> player);
}
