using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricalFrameLib
{
    /// <summary>
    /// This class represents a rectangle.
    /// </summary>
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

        /// <summary>
        /// set new origin
        /// </summary>
        /// <param name="newOriginPoint"></param>
        public void MoveShape(Point newOriginPoint)
        {
            this.Origin = newOriginPoint;
        }

        /// <summary>
        /// resize rectangle
        /// </summary>
        /// <param name="resizeFactor"></param>
        public void ResizeShape(Point resizeFactor)
        {
            this.Width = resizeFactor.x;
            this.Height = resizeFactor.y;
        }

        /// <summary>
        /// Draw rectangle
        /// </summary>
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
