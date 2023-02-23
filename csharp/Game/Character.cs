namespace Game;

public class Character
{
    internal readonly int armorClass;
    internal readonly int damageDealt;

    public Character(int armorClass, int weaponDamage, string race, int force)
    {
        this.armorClass = armorClass;
        damageDealt = weaponDamage;
        Race = race;
        Force = force;
    }

    internal int Force { get; set; }

    public string Race { get; internal set; }
}