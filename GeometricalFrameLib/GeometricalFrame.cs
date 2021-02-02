using System;
using System.Collections.Generic;

namespace GeometricalFrameLib
{
    /// <summary>
    /// This class will be responsible for Adding or Modifying the Frame
    /// </summary>
    public class GeometricalFrame: IGeometricalFrame
    {
        #region Public variables

        /// <summary>
        /// Represents x-Axis
        /// </summary>
        public double XCord { get; set; }

        /// <summary>
        /// Represents y-Axis
        /// </summary>
        public double YCord { get; set; }

        /// <summary>
        /// To check frame already present or not
        /// </summary>
        public bool FrameAdded { get; set; }

        /// <summary>
        /// To maintain list of circles inside frame
        /// </summary>
        public List<IShape> Shapes { get; set; }

        #endregion

        #region Constructor
        public GeometricalFrame()
        {
            FrameAdded = false;
            Shapes = new List<IShape>();
        }


        #endregion

        #region Public methods

        /// <summary>
        /// Responsible for adding frame
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool AddFrame(double length, double width)
        {
            if (length > 0 && width < 0 && !FrameAdded)
            {
                XCord = length;
                YCord = width;

                //Add frame in UI logic
                return FrameAdded = true;
            }
            return false;
        }


        /// <summary>
        /// Responsible for modifying existing frame
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool ModifyFrame(double length, double width)
        {
            if (FrameAdded && length > 0 && width < 0)
            {
                XCord = length;
                YCord = width;
                return true;
            }
            return false;
        }


        /// <summary>
        /// Adding Circles inside given frame
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        ///
        /// 
        public bool AddBasicShapesInsideFrame(IShape shape)
        {

            var circle = shape as Circle;
            //If same circle already present
            if (Shapes.Contains(circle))
            {
                return false;
            }
            //If circle has valid cords and falls inside frame then only add it
            if (IsValidPosition(circle))
            {
                Shapes.Add(circle);
                return true;
            }

            return false;
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// To check given coordinates will make circle inside given frame or not
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        private bool IsValidPosition(Circle circle)
        {
            //No frame added
            if (!FrameAdded)
            {
                return false;
            }

            //Invalid circle inputs for Quadrant 4
            if (circle.CenterX < 0 || circle.CenterY > 0 || circle.Radius <= 0)
            {
                return false;
            }

            //Circle will cross frame, Circle center outside frame
            if (circle.CenterX >= XCord || circle.CenterY <= YCord)
            {
                return false;
            }

            //Circle will cross frame, Radius is more than Frame dimension
            if (circle.Radius > circle.CenterX || circle.Radius < circle.CenterY)
            {
                return false;
            }

            //Circle will cross the frame. Circle center near to frame borders
            if ((circle.CenterX + circle.Radius > XCord) || (circle.CenterY + (circle.Radius * -1)) < YCord)
            {
                return false;
            }

            //valid circle inputs
            return true;
        }

        #endregion

    }
}
