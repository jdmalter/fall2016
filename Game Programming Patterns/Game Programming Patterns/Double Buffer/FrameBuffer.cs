namespace Game_Programming_Patterns.Double_Buffer
{
    public class FrameBuffer
    {
        private static readonly uint Width = 160;
        private static readonly uint Height = 120;
        private static readonly uint Area = Width * Height;

        public char[] Pixels { get; } = new char[Area];

        public FrameBuffer()
        {
            Clear();
        }

        public void Clear()
        {
            for (int i = 0; i < Area; i++)
            {
                Pixels[i] = 'w';
            }
        }

        public void Draw(uint x, uint y)
        {
            Pixels[(Width * y) + x] = 'b';
        }
    }
}
