using FluentAssertions;
using Xunit;

namespace Game.tests;

public class DiceShould
{
    private const int DiceSideCount = 20;
    private readonly Dice dice;

    public DiceShould()
        => dice = new Dice(DiceSideCount);

    [Fact]
    public void Roll_between_1_and_20()
        => dice.Roll()
            .Should()
            .BeInRange(1, DiceSideCount);
}