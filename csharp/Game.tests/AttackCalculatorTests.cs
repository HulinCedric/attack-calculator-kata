using System;
using System.Text;
using System.Threading.Tasks;
using FsCheck.Xunit;
using VerifyXunit;
using Xunit;

namespace Game.tests;

public class SnapshotFixture : IDisposable
{
    public SnapshotFixture()
        => Snapshot = new StringBuilder();

    public StringBuilder Snapshot { get; }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }
}

public class AttackCalculatorTests : VerifyBase, IClassFixture<SnapshotFixture>
{
    private readonly SnapshotFixture snapshotFixture;

    public AttackCalculatorTests(SnapshotFixture snapshotFixture) : base()
    {
        this.snapshotFixture = snapshotFixture;
    }

    [Property(Replay = "1145655947, 296144285")]
    public async Task HeroAttacksMonster(int defendersArmorClass, int attackersForce, int attackersDamage)
    {
        var diceRolled = new[] { 1, 4, 5, 20 };

        snapshotFixture.Snapshot.Append($"[{attackersDamage}, {attackersForce}, {defendersArmorClass}, 1] => ");

        var result = DoAttackCalculation(attackersDamage, attackersForce, defendersArmorClass, 1);

        snapshotFixture.Snapshot.AppendLine($"{result}");

        await Verify(snapshotFixture.Snapshot.ToString())
            .UseParameters(defendersArmorClass, attackersForce, attackersDamage);
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