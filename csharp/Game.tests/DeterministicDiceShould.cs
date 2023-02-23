using FluentAssertions;
using Xunit;

namespace Game.tests;

public class DeterministicDiceShould
{
    private const int ConstantRollingValue = 5;

    private readonly IDice dice;

    public DeterministicDiceShould()
        => dice = new DeterministicDice(ConstantRollingValue);

    [Fact]
    public void Roll_always_with_same_value()
        => dice.Roll()
            .Should()
            .Be(ConstantRollingValue);
}