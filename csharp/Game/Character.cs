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

    public int Attack(Character defender, int diceRoll)
        => IsAttackMissed(defender, diceRoll) ?
               NoDamage :
               ComputeAttackDamage(diceRoll);

    private bool IsAttackMissed(Character defender, int diceRoll)
    {
        var attackRoll = force + diceRoll;
        return attackRoll <= defender.armorClass;
    }

    private int ComputeAttackDamage(int diceRoll)
        => diceRoll switch
        {
            1 => NoDamage,
            20 => weaponDamage * 2,
            _ => weaponDamage
        };
}