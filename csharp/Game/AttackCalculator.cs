namespace Game;

public class AttackCalculator
{
    private readonly IDice dice;

    public AttackCalculator(IDice dice)
        => this.dice = dice;

    public int CalculateDamage(Character atk, Character def)
    {
        var diceRolled = dice.Roll();

        if (atk.Force + diceRolled <= def.armorClass)
            return 0;

        if (diceRolled == 1)
            return 0;

        if (diceRolled == 20)
            return atk.damageDealt * 2;

        return atk.damageDealt;
    }
}