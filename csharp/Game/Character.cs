namespace Game;

public class Character
{
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

    public int Attack(Character defender, IDice dice)
    {
        var attackRoll = dice.Roll();

        if (!CanInflictDamage(defender, attackRoll))
            return 0;

        return attackRoll switch
        {
            1 => 0,
            20 => weaponDamage * 2,
            _ => weaponDamage
        };
    }

    private bool CanInflictDamage(Character defender, int attackRoll)
    {
        var attackerForce = force + attackRoll;
        var defenderArmor = defender.armorClass;

        return attackerForce > defenderArmor;
    }
}