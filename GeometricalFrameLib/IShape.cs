using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricalFrameLib
{
    public class Point
    {
        public double CetnerX;
        public double CetnerY;

        public Point(double cetnerX, double cetnerY)
        {
            CetnerX = cetnerX;
            CetnerY = cetnerY;
        }
    }
    public interface IShape
    {
    }
}
