using System;

namespace Game;

public interface IDice
{
    int Roll();
}

public class DeterministicDice : IDice
{
    private readonly int rolled;

    public DeterministicDice(int rolled)
        => this.rolled = rolled;

    public int Roll()
        => rolled;
}

public class RandomizedDice : IDice
{
    private readonly Random random = new();
    private readonly int sideCount;

    public RandomizedDice(int sideCount)
        => this.sideCount = sideCount;

    public int Roll()
        => random.Next(1, sideCount);
}