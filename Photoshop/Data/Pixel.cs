using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop
{
    public struct Pixel
    {
        private double _red;

        public double Red
        {
            get { return _red; }

            set { _red = Chek(value); }
        }

        private double _green;
        public double Green
        {
            get { return _green; }

            set { _green = Chek(value); }
        }
        private double _blue;

        public double Blue
        {
            get { return _blue; }

            set { _blue = Chek(value); }
        }

        private double Chek(double color)
        {
            if (color < 0 || color > 1) throw new ArgumentException();
            else return color;

        }

        public static Pixel operator *(Pixel pixel, double x)
        {
            var result = new Pixel
            {
                Red = pixel.Red * x,
                Green = pixel.Green * x,
                Blue = pixel.Blue * x
            };
            return result;
        }


    }
}
