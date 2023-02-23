using FluentAssertions;
using Xunit;

namespace Game.tests;

public class CharacterAttackShould
{
    [Fact]
    public void Should_not_inflict_damage_when_attack_roll_is_less_or_equal_than_defender_armor_class()
    {
        var attacker = new Character(0, 3, "human", 2);
        var defender = new Character(8, 0, "orc", 0);
        var dice = new DeterministicDice(6);

        // Act
        var damage = attacker.Attack(defender, dice);

        // Assert
        damage.Should().Be(0);
    }


    [Fact]
    public void Should_inflict_weapon_damage_when_attack_roll_is_greater_than_defender_armor_class()
    {
        // Arrange
        var attacker = new Character(0, 3, "human", 2);
        var defender = new Character(8, 0, "orc", 0);
        var dice = new DeterministicDice(10);

        // Act
        var damage = attacker.Attack(defender, dice);

        // Assert
        damage.Should().Be(3);
    }

    [Fact]
    public void Should_inflict_double_damage_when_attack_roll_is_20()
    {
        // Arrange
        var attacker = new Character(0, 3, "human", 2);
        var defender = new Character(8, 0, "orc", 0);
        var dice = new DeterministicDice(20);

        // Act
        var damage = attacker.Attack(defender, dice);

        // Assert
        damage.Should().Be(6);
    }
}