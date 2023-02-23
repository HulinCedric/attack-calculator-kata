using System;

namespace Game;

public class Dice
{
    private readonly int sideCount;
    
    private readonly Random random = new();

    public Dice(int sideCount)
        => this.sideCount = sideCount;

    public int Roll()
        => random.Next(1, sideCount);
}