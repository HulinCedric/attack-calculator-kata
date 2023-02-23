using FluentAssertions;
using Xunit;

namespace Game.tests;

public class DiceShould
{
    [Fact]
    public void Roll_between_1_and_20()
    {
        var rolled = new Dice(20).Roll();

        rolled.Should().BeInRange(1, 20);
    }
}