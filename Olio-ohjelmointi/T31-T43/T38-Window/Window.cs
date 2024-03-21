using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Window
    {
        private double area;
        private double circumference;
        private double glassamount;
        public double Height { get; set; }
        public double Widht { get; set; }
        public double Diameter { get; set; }
        public double Area { get { return area; } }
        public double Circumference { get { return circumference; } }
        public double Glassamount { get { return glassamount; } }

        public void CalculateAreaRectangle()
        {
            area = Math.Round((Height * Widht), 3);
        }
        public void CalculateAreaCircle()
        {
            double radius = (Diameter / 2);
            area = Math.Round((Math.PI * Math.Pow(radius, 2)),3);
        }
        public void CalculateCircumferenceRectangle()
        {
            circumference = Math.Round((2 * Height + 2 * Widht),3);
        }
        public void CalculateCircumferenceCircle()
        {
            double radius = (Diameter / 2);
            circumference = Math.Round((2 * radius * Math.PI),3);
        }
        public void CalculateGlassAmountRectangle()
        {
            glassamount = Math.Round((area * 3), 3);
        }
        public void CalculateGlassAmountCircle()
        {
            glassamount = Math.Round((area * 3),3);
        }
    }
}
