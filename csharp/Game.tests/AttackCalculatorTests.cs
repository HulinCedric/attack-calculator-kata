using System;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using Bogus;
using Xunit;

namespace Game.tests;

[UseReporter(typeof(DiffReporter))]
public class AttackCalculatorTests
{
    private readonly Faker faker;

    public AttackCalculatorTests()
    {
        Randomizer.Seed = new Random(42);

        faker = new Faker();
    }

    [Fact]
    public void HeroAttacksMonster()
    {
        var defendersArmorClass = new[] { 1, 5 };
        var attackersForce = new[] { 1, 5 };
        var attackersDamage = new[] { 1, 5 };
        var diceRolled = new[] { 1, 4, 5, 20 };

        CombinationApprovals.VerifyAllCombinations(
            (a, b, c, d) => DoAttackCalculation(a, b, c, d),
            attackersDamage,
            attackersForce,
            defendersArmorClass,
            diceRolled);
    }

    private static int DoAttackCalculation(
        int attackersDamage,
        int attackersForce,
        int defendersArmorClass,
        int diceRolled)
    {
        var attacker = new Character(1, attackersDamage, "human", attackersForce);
        var defender = new Character(defendersArmorClass, 1, "orc", 1);
        var dice = new DeterministicDice(diceRolled);
        var attackCalculator = new AttackCalculator(dice);
        var damage = attackCalculator.CalculateDamage(attacker, defender);
        return damage;
    }
}