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

        return diceRolled switch
        {
            1 => 0,
            20 => atk.damageDealt * 2,
            _ => atk.damageDealt
        };
    }
}