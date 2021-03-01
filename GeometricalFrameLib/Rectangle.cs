using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricalFrameLib
{
    public class Rectangle:IShape
    {
        public Point Origin { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public Rectangle(Point origin,double height,double width)
        {
            this.Origin = origin;
            this.Height = height;
            this.Width = width;
        }

        public void MoveShape(Point newOriginPoint)
        {
            this.Origin = newOriginPoint;
        }

        public void ResizeShape(Point resizeFactor)
        {
            this.Width = resizeFactor.x;
            this.Height = resizeFactor.y;
        }

        public void DrawShape()
        {
            Console.WriteLine("Rectangle cordinates, Origin Point:({0},{1})  Width:{2} Height:{3}", this.Origin.x, this.Origin.y, this.Width,this.Width);
        }

        public void ResizeShape(double resizeFactor)
        {
            throw new NotImplementedException();
        }
    }
}
