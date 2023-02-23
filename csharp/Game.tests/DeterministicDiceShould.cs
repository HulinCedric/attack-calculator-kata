using FluentAssertions;
using Game.tests.Common.Extensions;
using Xunit;

namespace Game.tests;

public class DeterministicDiceShould
{
    private const int RolledDiceValue = 5;

    [Fact]
    public void Roll_always_with_same_value()
        => RolledDiceValue
            .Dice()
            .Roll()
            .Should()
            .Be(RolledDiceValue);
}