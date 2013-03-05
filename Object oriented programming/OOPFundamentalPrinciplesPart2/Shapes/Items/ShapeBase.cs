namespace Shapes.Items
{
    abstract class ShapeBase
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public ShapeBase(double width, double height) 
        {
            Width = width;
            Height = height;
        }

        public abstract double CalculateSurface();
    }
}
