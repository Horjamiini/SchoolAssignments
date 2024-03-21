using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public abstract class Shape
    {
        public string Name { get; set; }
        public abstract double Area { get;}
        public abstract double Circumference { get;}
        public abstract double CalculateArea();
        public abstract double CalculateCirfumference();
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area { get { return CalculateArea(); }}
        public override double Circumference { get { return CalculateCirfumference(); }}
        public Circle(double radius)
        {
            Name = "Circle";
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.Round(Math.PI * Math.Pow(Radius,2),2);
        }
        public override double CalculateCirfumference()
        {
            return Math.Round(2 * Math.PI * Radius,2);
        }
        public override string ToString()
        {
            return $"{Name} Radius={Radius.ToString(CultureInfo.InvariantCulture)} Area={Area.ToString(CultureInfo.InvariantCulture)} Circumference={Circumference.ToString(CultureInfo.InvariantCulture)}";
        }
    }
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public override double Area { get { return CalculateArea();} }
        public override double Circumference { get { return CalculateCirfumference(); } }
        public Rectangle(double height,double width)
        {
            Name = "Rectangle";
            Height = height;
            Width = width;
        }
        public override double CalculateArea()
        {
            return Height * Width;
        }
        public override double CalculateCirfumference()
        {
            return 2 * Height + 2 * Width;
        }
        public override string ToString()
        {
            return $"{Name} Width={Width.ToString(CultureInfo.InvariantCulture)} Height={Height.ToString(CultureInfo.InvariantCulture)} Area={Area.ToString( CultureInfo.InvariantCulture)} Circumference={Circumference.ToString(CultureInfo.InvariantCulture)}";
        }
    }
    public class Shapes
    {
        private List<Shape> _patterns;
        public List<Shape> Patterns { get { return _patterns; } }
        public Shapes()
        {
            _patterns = new List<Shape>();
        }
    }
    internal class Program
    {
        static void TestPatterns()
        {
            Shapes shapes = new Shapes();
            shapes.Patterns.Add(new Circle(1));
            shapes.Patterns.Add(new Circle(2));
            shapes.Patterns.Add(new Circle(3));
            shapes.Patterns.Add(new Rectangle(10.5,20.05));
            shapes.Patterns.Add(new Rectangle(20,30));
            shapes.Patterns.Add(new Rectangle(40,50));

            foreach(Shape shape in shapes.Patterns)
            {
                Console.WriteLine(shape.ToString());
            }
        }
        static void Main(string[] args)
        {
            TestPatterns();
        }
    }
}
