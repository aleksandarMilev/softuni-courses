namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height
        {
            get => height;
            private set => height = value;
        }
        public int Width
        {
            get => width;
            private set => width = value;
        }

        public override double CalculateArea()
            => Height * Width;

        public override double CalculatePerimeter()
            => 2 * Height + 2 * Width;
    }
}
