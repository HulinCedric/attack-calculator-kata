using System.Text;
using System.Threading.Tasks;
using FsCheck;
using VerifyXunit;
using Xunit;

namespace Game.tests;

[UsesVerify]
public class AttackCalculatorTests
{
    [Fact]
    public async Task HeroAttacksMonster()
    {
        var output = new StringBuilder();

        var diceRolled = new[] { 1, 4, 5, 20 };

        Prop.ForAll<int, int, int>(
                (defendersArmorClass, attackersForce, attackersDamage) =>
                {
                    output.Append($"[{attackersDamage}, {attackersForce}, {defendersArmorClass}, 1] => ");

                    var result = DoAttackCalculation(attackersDamage, attackersForce, defendersArmorClass, 1);

                    output.AppendLine($"{result}");

                    return true;
                })
            .Check(new Configuration { Replay = Random.StdGen.NewStdGen(1145655947, 296144285) });

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