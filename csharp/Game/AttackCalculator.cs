namespace Game
{
    public class AttackCalculator
    {
        private readonly IDice dice;

        public AttackCalculator(IDice dice)
            => this.dice = dice;

        public int CalculateDamage(Character atk, Character def)
        {
            var diceRolled = dice.Roll();
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