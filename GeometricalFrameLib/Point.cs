using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace GeometricalFrameLib
{
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point(double x,double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class ResizeFactor
    {
        public double Radius { get; set; }

        public Point NewValue { get; set; }

        public ResizeFactor(double radius)
        {
            this.Radius = radius;
        }

        public ResizeFactor(double width, double height)
        {
            NewValue =  new Point(width, height);
        }

        public ResizeFactor(Point newValue)
        {
            this.NewValue = newValue;
        }
    }
}
