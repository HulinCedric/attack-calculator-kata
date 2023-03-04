using System;
using System.Text;
using System.Threading.Tasks;
using FsCheck;
using VerifyXunit;
using Xunit;
using Random = FsCheck.Random;

namespace Game.tests;

[UsesVerify]
public class AttackCalculatorTests
{
    private readonly Configuration configuration;

    public AttackCalculatorTests()
    {
        configuration = Configuration.Default;
        configuration.Replay = Random.StdGen.NewStdGen(1145655947, 296144285);
    }

    private static Arbitrary<Tuple<int, int, int, int>> InputGenerator()
        => Arb.Default.Int32().Filter(x => x is >= 0 and <= 20).Generator.Four().ToArbitrary();

    [Fact]
    public async Task HeroAttacksMonster()
    {
        var output = new StringBuilder();

        Prop.ForAll(
                InputGenerator(),
                inputs =>
                {
                    var (attackersDamage, attackersForce, defendersArmorClass, diceRolled) = inputs;

                    output.Append($"[{attackersDamage}, {attackersForce}, {defendersArmorClass}, {diceRolled}] => ");

                    var result = DoAttackCalculation(attackersDamage, attackersForce, defendersArmorClass, diceRolled);

                    output.AppendLine($"{result}");

                    return true;
                })
            .Check(configuration);

        await Verifier.Verify(output.ToString());
    }

    private static int DoAttackCalculation(
        int attackersDamage,
        int attackersForce,
        int defendersArmorClass,
        int diceRolled)
    {
        var attacker = new Character(1, attackersDamage, "human", attackersForce);
        var defender = new Character(defendersArmorClass, 1, "orc", 1);
        var damage = AttackCalculator.CalculateDamage(attacker, defender, diceRolled);
        return damage;
    }
}