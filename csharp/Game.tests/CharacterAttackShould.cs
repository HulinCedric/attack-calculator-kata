using FluentAssertions;
using Xunit;

namespace Game.tests;

public class CharacterAttackShould
{
    [Fact]
    public void Should_return_zero_when_attack_is_less_or_equal_than_defender_armor_class()
    {
        var attacker = new Character(0, 3, "human", 5);
        var defender = new Character(10, 0, "orc", 0);
        var dice = new DeterministicDice(5);

        // Act
        var damage = attacker.Attack(defender, dice);

        // Assert
        damage.Should().Be(0);
    }
}