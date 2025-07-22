namespace Hearthstone.Game.Players;

public class ManaCrystals
{
    private readonly int _maxCapacity;

    public ManaCrystals(int initCapacity, int maxCapacity)
    {
        Capacity = Current = initCapacity;
        _maxCapacity = maxCapacity;
    }

    public int Capacity { get; private set; }

    public int Current { get; private set; }

    public bool NoCrystals => Current <= 0;

    public void AddCapacity(int count)
    {
        if (Capacity + count > _maxCapacity)
        {
            Capacity = _maxCapacity;
        }
        else
        {
            Capacity += count;
        }
    }

    public void AddCrystal(int count)
    {
        Current += count;
    }

    public bool HasCrystals(int count) => Current >= count;

    public bool UseCrystals(int count)
    {
        if (HasCrystals(count))
        {
            Current -= count;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        Current = Capacity;
    }
}
