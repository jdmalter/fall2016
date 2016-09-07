namespace Game_Programming_Patterns.Type_Object
{
    public class Monster
    {
        private Breed _breed;

        public Monster(Breed breed)
        {
            _breed = breed;
            Health = breed.Health;
        }

        // current health
        public int Health { get; set; }

        // use breed's attack string
        public string Attack { get { return _breed.Attack; } }
    }
}
