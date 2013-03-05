using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Items;

namespace Shapes
{
    public static class TestShapes
    {
        public static void Run() 
        {
            var shapes = new ShapeBase[]
            {
                new Triangle(10,20),
                new Triangle(2,4),
                new Triangle(18,6),
                new Circle(10),
                new Circle(7),
                new Circle(4),
                new Rectangle(4,12),
                new Rectangle(2,32),
                new Rectangle(7,28),
            };

            PrintSortedShapes(shapes);
        }

        private static void PrintSortedShapes(ShapeBase[] shapes)
        {
            const string resultFormat = "surface: [{0:0}] \t type: [{1}]";

            var orderedShapes = shapes.OrderBy(x => x.CalculateSurface());
            foreach (var shape in orderedShapes)
            {
                Console.WriteLine(resultFormat, shape.CalculateSurface(), shape.GetType().Name);
            }
        }
    }
}
