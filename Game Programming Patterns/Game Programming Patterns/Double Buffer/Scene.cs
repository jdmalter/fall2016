namespace Game_Programming_Patterns.Double_Buffer
{
    public class Scene
    {
        private FrameBuffer _currentBuffer = new FrameBuffer();
        private FrameBuffer _nextBuffer = new FrameBuffer();

        public void Draw()
        {
            _nextBuffer.Clear();

            _nextBuffer.Draw(1, 1);
            _nextBuffer.Draw(4, 1);
            _nextBuffer.Draw(1, 3);
            _nextBuffer.Draw(2, 4);
            _nextBuffer.Draw(3, 4);
            _nextBuffer.Draw(4, 3);

            Swap();
        }

        private void Swap()
        {
            FrameBuffer temp = _currentBuffer;
            _currentBuffer = _nextBuffer;
            _nextBuffer = temp;
        }

        public FrameBuffer Buffer { get { return _currentBuffer; } }
    }
}
