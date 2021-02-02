using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometricalFrameLib
{

    /// <summary>
    /// This class represents a circle.Responsible for Adding circle inside frame.
    /// </summary>
   public class Circle : IShape
    {
        #region private properties

        private Point centerPoint;

        #endregion
        #region Public properties

        /// <summary>
        /// x-cord of the circle center point
        /// </summary>
        public double CenterX { get; set; }

        /// <summary>
        /// y-cord of the circle center point
        /// </summary>
        public double CenterY { get; set; }

        /// <summary>
        /// circle radius
        /// </summary>
        public double Radius { get; set; }


        #endregion


        #region Constructor
       public Circle(Point centerPoint, double radius)
       {
           this.CenterX = centerPoint.CetnerX;
           this.CenterY = centerPoint.CetnerY;
            this.Radius = radius;
        }


        #endregion

    }
}
