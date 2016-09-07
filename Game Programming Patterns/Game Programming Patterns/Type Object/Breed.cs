namespace Game_Programming_Patterns.Type_Object
{
    public class Breed
    {
        public Breed(Breed parent, int health, string attack)
        {
            if (parent != null)
            {
                Health = health == 0 ? parent.Health : health;
                Attack = attack == null ? parent.Attack : attack;
            }
        }

        // Starting health
        public int Health { get; private set; }

        // Message displayed when attacking
        public string Attack { get; private set; }

        public Monster newMonster()
        {
            return new Monster(this);
        }
    }
}
