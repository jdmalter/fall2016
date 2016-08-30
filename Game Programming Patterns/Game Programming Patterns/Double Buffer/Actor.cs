namespace Game_Programming_Patterns.Double_Buffer
{
    public abstract class Actor
    {
        private bool _currentSlapped = false;
        private bool _nextSlapped;

        bool Slapped { get { return _currentSlapped; } set { _nextSlapped = value; } }

        public void Swap()
        {
            _currentSlapped = _nextSlapped;
            _nextSlapped = false;
        }

        public abstract void Update();
    }
}
