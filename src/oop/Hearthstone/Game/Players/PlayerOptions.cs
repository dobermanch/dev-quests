namespace Hearthstone.Game.Players;

public record PlayerOptions
{
    public int InitialHitPoints { get; init; } = 30;

    public int InitialHandSize { get; init; } = 4;

    public int InitialManaCrystals { get; init; } = 1;

    public int MaxManaCrystals { get; init; } = 10;
}
