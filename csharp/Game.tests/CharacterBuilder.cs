namespace Game.tests;

public class CharacterBuilder
{
    private readonly string race;
    private int _armorClass;
    private int _force;
    private int _weaponDamage;

    private CharacterBuilder(int armorClass, int weaponDamage, string race, int force)
    {
        _armorClass = armorClass;
        _weaponDamage = weaponDamage;
        this.race = race;
        _force = force;
    }

    public static CharacterBuilder Human()
        => new(5, 5, "human", 5);

    public static CharacterBuilder Orc()
        => new(5, 5, "orc", 5);

    public CharacterBuilder WithArmorClass(int armorClass)
    {
        _armorClass = armorClass;

        return this;
    }

    public CharacterBuilder WithWeaponDamage(int weaponDamage)
    {
        _weaponDamage = weaponDamage;

        return this;
    }

    public CharacterBuilder WithForce(int force)
    {
        _force = force;

        return this;
    }

    public Character Build()
        => new(_armorClass, _weaponDamage, race, _force);
}