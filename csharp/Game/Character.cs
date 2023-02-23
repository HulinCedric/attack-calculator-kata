﻿namespace Game;

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

    public int Attack(Character other, IDice dice)
    {
        var diceRolled = dice.Roll();

        if (force + diceRolled <= other.armorClass)
            return 0;

        return diceRolled switch
        {
            1 => 0,
            20 => weaponDamage * 2,
            _ => weaponDamage
        };
    }
}