namespace Game.tests.Common.Extensions;

public static class DiceExtensions
{
    public static IDice Dice(this int rolledDiceValue)
        => new DeterministicDice(rolledDiceValue);
}