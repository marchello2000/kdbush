using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDBush
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Id { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point(double x, double y, int id)
        {
            X = x;
            Y = y;
            Id = id;
        }
    }
}
