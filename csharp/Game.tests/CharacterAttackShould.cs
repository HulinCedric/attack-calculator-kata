using FluentAssertions;
using Xunit;
using static Game.tests.Common.Builders.CharacterBuilder;

namespace Game.tests;

public class CharacterAttackShould
{
    [Fact]
    public void Should_not_inflict_damage_when_attack_roll_is_less_or_equal_than_defender_armor_class()
    {
        // Arrange
        const int attackRoll = 6;
        var attacker = Human().WithForce(2).WithWeaponDamage(3).Build();

        var defender = Orc().WithArmorClass(8).Build();

        // Act
        var damage = attacker.Attack(defender, attackRoll);

        // Assert
        damage.Should().Be(0);
    }

    [Fact]
    public void Should_inflict_weapon_damage_when_attack_roll_is_greater_than_defender_armor_class()
    {
        // Arrange
        const int attackRoll = 10;
        var attacker = Human().WithWeaponDamage(3).Build();

        var defender = Orc().WithArmorClass(8).Build();

        // Act
        var damage = attacker.Attack(defender, attackRoll);

        // Assert
        damage.Should().Be(3);
    }

    [Fact]
    public void Should_inflict_double_damage_when_attack_roll_is_20()
    {
        // Arrange
        const int attackRoll = 20;
        var attacker = Human().WithForce(2).WithWeaponDamage(3).Build();

        var defender = Orc().WithArmorClass(8).Build();

        // Act
        var damage = attacker.Attack(defender, attackRoll);

        // Assert
        damage.Should().Be(6);
    }

    [Fact]
    public void Should_not_inflict_damage_when_attack_roll_is_1()
    {
        // Arrange
        const int attackRoll = 1;
        var attacker = Human().WithForce(4).WithWeaponDamage(3).Build();

        var defender = Orc().WithArmorClass(4).Build();

        // Act
        var damage = attacker.Attack(defender, attackRoll);

        // Assert
        damage.Should().Be(0);
    }
}