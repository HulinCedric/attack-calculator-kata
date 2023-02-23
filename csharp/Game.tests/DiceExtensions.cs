namespace Game.tests;

public static class DiceExtensions
{
    public static IDice DiceValue(this int rolledDiceValue)
        => new DeterministicDice(rolledDiceValue);
}