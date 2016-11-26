namespace Artificial_Intelligence.Environment.Map.Romania
{
    /// <summary>
    /// A Romanian map agents's actions through actuators on an environment. 
    /// </summary>
    public class RomaniaMapAction : MapAction<RomaniaMapState>
    {
        public static readonly RomaniaMapAction GO_ARAD = new RomaniaMapAction(RomaniaMapState.ARAD);
        public static readonly RomaniaMapAction GO_BUCHAREST = new RomaniaMapAction(RomaniaMapState.BUCHAREST);
        public static readonly RomaniaMapAction GO_CRAIOVA = new RomaniaMapAction(RomaniaMapState.CRAIOVA);
        public static readonly RomaniaMapAction GO_DROBETA = new RomaniaMapAction(RomaniaMapState.DROBETA);
        public static readonly RomaniaMapAction GO_EFORIE = new RomaniaMapAction(RomaniaMapState.EFORIE);
        public static readonly RomaniaMapAction GO_FAGARAS = new RomaniaMapAction(RomaniaMapState.FAGARAS);
        public static readonly RomaniaMapAction GO_GIURGIU = new RomaniaMapAction(RomaniaMapState.GIURGIU);
        public static readonly RomaniaMapAction GO_HIRSOVA = new RomaniaMapAction(RomaniaMapState.HIRSOVA);
        public static readonly RomaniaMapAction GO_IASI = new RomaniaMapAction(RomaniaMapState.IASI);
        public static readonly RomaniaMapAction GO_LUGOJ = new RomaniaMapAction(RomaniaMapState.LUGOJ);
        public static readonly RomaniaMapAction GO_MEHADIA = new RomaniaMapAction(RomaniaMapState.MEHADIA);
        public static readonly RomaniaMapAction GO_NEAMT = new RomaniaMapAction(RomaniaMapState.NEAMT);
        public static readonly RomaniaMapAction GO_ORADEA = new RomaniaMapAction(RomaniaMapState.ORADEA);
        public static readonly RomaniaMapAction GO_PITESTI = new RomaniaMapAction(RomaniaMapState.PITESTI);
        public static readonly RomaniaMapAction GO_RIMNICU_VILCEA = new RomaniaMapAction(RomaniaMapState.RIMNICU_VILCEA);
        public static readonly RomaniaMapAction GO_SIBIU = new RomaniaMapAction(RomaniaMapState.SIBIU);
        public static readonly RomaniaMapAction GO_TIMISOARA = new RomaniaMapAction(RomaniaMapState.TIMISOARA);
        public static readonly RomaniaMapAction GO_URZICENI = new RomaniaMapAction(RomaniaMapState.URZICENI);
        public static readonly RomaniaMapAction GO_VASLUI = new RomaniaMapAction(RomaniaMapState.VASLUI);
        public static readonly RomaniaMapAction GO_ZERIND = new RomaniaMapAction(RomaniaMapState.ZERIND);

        /// <summary>
        /// Specifies a Romanian map agent's memory of its environment.
        /// </summary>
        /// <param name="state">A Romanian map agent's memory of its environment.</param>
        private RomaniaMapAction(RomaniaMapState state) : base(state)
        {

        }
    }
}
