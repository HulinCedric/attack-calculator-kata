namespace Game
{
    public class AttackCalculator
    {
        private readonly Dice dice = new(20);

        public int CalculateDamage(Character atk, Character def)
        {
            var diceRolled = dice.Roll();
            return CalculateDamage(atk, def, diceRolled);
        }

        public static int CalculateDamage(Character atk, Character def, int diceRolled)
        {
            var damage = atk.damageDealt;

            if (atk.Force + diceRolled > def.armorClass)
            {
                if (diceRolled == 1)
                {
                    damage = 0;
                }

                if (diceRolled == 20)
                {
                    damage = atk.damageDealt * 2;
                }

                return damage;
            }

            return 0;
        }
    }
}