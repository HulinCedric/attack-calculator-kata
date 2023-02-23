namespace Game;

public class Character
{
    private const int NoDamage = 0;
    private readonly int armorClass;
    private readonly int force;
    private readonly string race;
    private readonly int weaponDamage;

    public Character(int armorClass, int weaponDamage, string race, int force)
    {
        this.armorClass = armorClass;
        this.weaponDamage = weaponDamage;
        this.race = race;
        this.force = force;
    }

    public int Attack(Character defender, int attackRoll)
        => CanInflictDamage(defender, attackRoll) ?
               GetDamage(attackRoll) :
               NoDamage;

    private int GetDamage(int attackRoll)
        => attackRoll switch
        {
            1 => NoDamage,
            20 => weaponDamage * 2,
            _ => weaponDamage
        };

    private bool CanInflictDamage(Character defender, int attackRoll)
    {
        var attackerForce = force + attackRoll;
        var defenderArmor = defender.armorClass;

        return attackerForce > defenderArmor;
    }
}