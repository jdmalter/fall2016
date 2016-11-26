namespace Artificial_Intelligence.Environment.Map.Romania
{
    /// <summary>
    /// An agent's memory of its environment.
    /// </summary>
    public class RomaniaMapState : MapState
    {
        public static readonly RomaniaMapState ARAD = new RomaniaMapState("Arad");
        public static readonly RomaniaMapState BUCHAREST = new RomaniaMapState("Bucharest");
        public static readonly RomaniaMapState CRAIOVA = new RomaniaMapState("Craiova");
        public static readonly RomaniaMapState DROBETA = new RomaniaMapState("Drobeta");
        public static readonly RomaniaMapState EFORIE = new RomaniaMapState("Eforie");
        public static readonly RomaniaMapState FAGARAS = new RomaniaMapState("Fagaras");
        public static readonly RomaniaMapState GIURGIU = new RomaniaMapState("Giurgiu");
        public static readonly RomaniaMapState HIRSOVA = new RomaniaMapState("Hirsova");
        public static readonly RomaniaMapState IASI = new RomaniaMapState("Iasi");
        public static readonly RomaniaMapState LUGOJ = new RomaniaMapState("Lugoj");
        public static readonly RomaniaMapState MEHADIA = new RomaniaMapState("Mehadia");
        public static readonly RomaniaMapState NEAMT = new RomaniaMapState("Neamt");
        public static readonly RomaniaMapState ORADEA = new RomaniaMapState("Oradea");
        public static readonly RomaniaMapState PITESTI = new RomaniaMapState("Pitesti");
        public static readonly RomaniaMapState RIMNICU_VILCEA = new RomaniaMapState("Rimnicu Vilcea");
        public static readonly RomaniaMapState SIBIU = new RomaniaMapState("Sibiu");
        public static readonly RomaniaMapState TIMISOARA = new RomaniaMapState("Timisoara");
        public static readonly RomaniaMapState URZICENI = new RomaniaMapState("Urziceni");
        public static readonly RomaniaMapState VASLUI = new RomaniaMapState("Vaslui");
        public static readonly RomaniaMapState ZERIND = new RomaniaMapState("Zerind");

        /// <summary>
        /// Specifies the string representation.
        /// </summary>
        /// <param name="name">The string representation.</param>
        private RomaniaMapState(string name) : base(name)
        {

        }

        /// <summary>
        /// Determines whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">Any object.</param>
        /// <returns>Whether the given object is equal to the current object.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj as RomaniaMapState);
        }

        /// <summary>
        /// Uses hash function of the string representation.
        /// </summary>
        /// <returns>A hash code for the string representation.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
