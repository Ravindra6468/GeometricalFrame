using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricalFrameLib
{
    interface IGeometricalFrame
    {
        /// <summary>
        /// Add Frame in Quadrant
        /// </summary>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public bool AddFrame(double width, double length);


        /// <summary>
        /// Modify already added Frame
        /// </summary>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public bool ModifyFrame(double width, double length);


        /// <summary>
        /// Add circle inside frame
        /// </summary>
        /// <param name="circle"></param>
        /// <param name="frame"></param>
        /// <returns></returns>
        public bool AddBasicShapesInsideFrame(IShape shape);
    }
}
