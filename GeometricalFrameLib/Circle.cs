using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GeometricalFrameLib
{

    /// <summary>
    /// This class represents a circle.
    /// </summary>
   public class Circle : IShape
    {

        #region Public properties

        public Point centerPoint { get; set; }

        /// <summary>
        /// circle radius
        /// </summary>
        public double Radius { get; set; }


        #endregion


        #region Constructor
       public Circle(Point centerPoint, double radius)
        {
            this.centerPoint = centerPoint;
            this.Radius = radius;
        }

        /// <summary>
        /// responsible for updating center point to new point
        /// </summary>
        /// <param name="updatedCenter"></param>
        public void MoveShape(Point updatedCenter)
        {
            this.centerPoint = updatedCenter;
        }

        /// <summary>
        /// Responsible for resize of circle
        /// </summary>
        /// <param name="updatedRadius"></param>
        public void ResizeShape(double updatedRadius)
        {
            if(this.Radius!=updatedRadius)
            {
                this.Radius = updatedRadius;
            }

        }

        /// <summary>
        /// Responsible for drawing circle cordinates
        /// </summary>
        public void DrawShape()
        {
            Console.WriteLine("Circle cordinates, Center Point:({0},{1}) Radius:{2}",this.centerPoint.x,this.centerPoint.y, this.Radius);
        }

        public void ResizeShape(Point resizeFactor)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
