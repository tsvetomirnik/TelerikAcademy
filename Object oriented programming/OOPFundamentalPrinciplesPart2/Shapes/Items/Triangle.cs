namespace Shapes.Items
{
    class Triangle : ShapeBase
    {
        public Triangle(double width, double height) 
            : base(width, height)
        {    
        }

        public override double CalculateSurface()
        {
            return (Width * Height) / 2;
        }
    }
}
