using System;

namespace Shapes.Items
{
    class Circle : ShapeBase
    {
        public Circle(double radius) 
            : base(radius, radius)
        {
        }

        public override double CalculateSurface()
        {
            return Math.PI * Height * Height;
        }
    }
}
