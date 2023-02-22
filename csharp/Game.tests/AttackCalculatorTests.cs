using FluentAssertions;
using Xunit;

namespace Game.tests;

public class AttackCalculatorTests
{
    [Theory]
    [InlineData(10, 5, "Elf", 12, 8, 3, "Dwarf", 10, 5, 5)]
    [InlineData(5, 2, "Human", 15, 20, 6, "Orc", 5, 2, 0)]
    [InlineData(15, 8, "Dwarf", 18, 12, 4, "Elf", 14, 8, 8)]
    public void Discovery(
        int attackerArmorClass, int attackerDamageDealt, string attackerRace, int attackerForce,
        int defenderArmorClass, int defenderDamageDealt, string defenderRace, int defenderForce,
        int rolledDice,
        int expectedDamage)
    {
        var attacker = new Character(attackerArmorClass, attackerDamageDealt, attackerRace, attackerForce);
        var defender = new Character(defenderArmorClass, defenderDamageDealt, defenderRace, defenderForce);
            
        var damage = AttackCalculator.CalculateDamage(attacker, defender, rolledDice);

        damage.Should().Be(expectedDamage);
    }
}