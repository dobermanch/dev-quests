namespace Hearthstone.Game.Players;

public class Health(int capacity)
{
    public int Current { get; private set; } = capacity;

    public bool IsDead => Current <= 0;

    public void Increase(int value) => Current += value;

    public void Decrease(int value) => Current -= value;
}
