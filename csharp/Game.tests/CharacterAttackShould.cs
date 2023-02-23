using FluentAssertions;
using Xunit;
using static Game.tests.Common.Builders.CharacterBuilder;

namespace Game.tests;

public class CharacterAttackShould
{
    [Fact]
    public void Be_missed_when_attack_roll_is_less_or_equal_than_defender_armor_class()
    {
        // Arrange
        const int diceRoll = 6;
        var attacker = Human().WithForce(2).WithWeaponDamage(3).Build();

        var defender = Orc().WithArmorClass(8).Build();

        // Act
        var damage = attacker.Attack(defender, diceRoll);

        // Assert
        damage.Should().Be(0);
    }

    [Fact]
    public void Be_hit_when_attack_roll_is_greater_than_defender_armor_class()
    {
        // Arrange
        const int weaponDamage = 3;

        const int diceRoll = 10;
        var attacker = Human().WithWeaponDamage(weaponDamage).Build();

        var defender = Orc().WithArmorClass(8).Build();

        // Act
        var damage = attacker.Attack(defender, diceRoll);

        // Assert
        damage.Should().Be(weaponDamage);
    }

    [Fact]
    public void Inflict_double_damage_when_dice_roll_is_20()
    {
        // Arrange
        const int weaponDamage = 3;
        const int doubleDamage = 6;

        const int diceRoll = 20;
        var attacker = Human().WithForce(2).WithWeaponDamage(weaponDamage).Build();

        var defender = Orc().WithArmorClass(8).Build();

        // Act
        var damage = attacker.Attack(defender, diceRoll);

        // Assert
        damage.Should().Be(doubleDamage);
    }

    [Fact]
    public void Inflict_no_damage_when_dice_roll_is_1()
    {
        // Arrange
        const int diceRoll = 1;
        var attacker = Human().WithForce(4).WithWeaponDamage(3).Build();

        var defender = Orc().WithArmorClass(4).Build();

        // Act
        var damage = attacker.Attack(defender, diceRoll);

        // Assert
        damage.Should().Be(0);
    }
}