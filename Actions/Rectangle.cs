namespace CloudinaryDotNet.Actions
{
    public struct Rectangle
    {
        public Rectangle(int x, int y, int width, int height) : this()
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
    }
}