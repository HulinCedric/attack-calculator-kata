using FluentAssertions;
using Xunit;
using static Game.tests.CharacterBuilder;

namespace Game.tests;

public class CharacterAttackShould
{
    [Fact]
    public void Should_not_inflict_damage_when_attack_roll_is_less_or_equal_than_defender_armor_class()
    {
        // Arrange
        var attacker = Human().WithForce(2).WithWeaponDamage(3).Build();
        var dice = 6.DiceValue();

        var defender = Orc().WithArmorClass(8).Build();

        // Act
        var damage = attacker.Attack(defender, dice.Roll());

        // Assert
        damage.Should().Be(0);
    }

    [Fact]
    public void Should_inflict_weapon_damage_when_attack_roll_is_greater_than_defender_armor_class()
    {
        // Arrange
        var attacker = Human().WithWeaponDamage(3).Build();
        var dice = 10.DiceValue();

        var defender = Orc().WithArmorClass(8).Build();

        // Act
        var damage = attacker.Attack(defender, dice.Roll());

        // Assert
        damage.Should().Be(3);
    }

    [Fact]
    public void Should_inflict_double_damage_when_attack_roll_is_20()
    {
        // Arrange
        var attacker = Human().WithForce(2).WithWeaponDamage(3).Build();
        var dice = 20.DiceValue();

        var defender = Orc().WithArmorClass(8).Build();

        // Act
        var damage = attacker.Attack(defender, dice.Roll());

        // Assert
        damage.Should().Be(6);
    }

    [Fact]
    public void Should_not_inflict_damage_when_attack_roll_is_1()
    {
        // Arrange
        var attacker = Human().WithForce(4).WithWeaponDamage(3).Build();
        var dice = 1.DiceValue();

        var defender = Orc().WithArmorClass(4).Build();

        // Act
        var damage = attacker.Attack(defender, dice.Roll());

        // Assert
        damage.Should().Be(0);
    }
}