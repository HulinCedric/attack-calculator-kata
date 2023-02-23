using FluentAssertions;
using Xunit;

namespace Game.tests;

public class RandomizedDiceShould
{
    private const int DiceSideCount = 20;
    private readonly RandomizedDice randomizedDice;

    public RandomizedDiceShould()
        => randomizedDice = new RandomizedDice(DiceSideCount);

    [Fact]
    public void Roll_between_1_and_20()
        => randomizedDice.Roll()
            .Should()
            .BeInRange(1, DiceSideCount);
}