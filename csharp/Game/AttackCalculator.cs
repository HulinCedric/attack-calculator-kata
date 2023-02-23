namespace Game;

public class AttackCalculator
{
    private readonly IDice dice;

    public AttackCalculator(IDice dice)
        => this.dice = dice;

    public IDice Dice
    {
        get { return dice; }
    }
}