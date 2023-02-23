namespace Game.tests;

public static class DiceExtensions
{
    public static IDice Dice(this int rolledDiceValue)
        => new DeterministicDice(rolledDiceValue);
}