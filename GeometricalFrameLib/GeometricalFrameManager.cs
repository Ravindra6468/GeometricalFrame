using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricalFrameLib
{
    public class GeometricalFrameManager
    {
        #region private variables
        private FrameOperations _frame;
        #endregion

        /// <summary>
        /// Responsible for adding frame
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool AddFrame(double length, double width)
        {
            if (_frame == null && length > 0 && width < 0)
            {
               _frame = new FrameOperations(length, width);
                _frame.FrameAdded = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// For getting frame object
        /// </summary>
        /// <returns></returns>
        public FrameOperations GetFrame()
        {
            return _frame;
        }

        /// <summary>
        /// For Modifying frame
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool ModifyFrame(double length, double width)
        {
            if (_frame != null && length > 0 && width < 0)
            {
                _frame.ModifyFrame(length, width);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Responsible for adding shapes inside frame
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public bool AddShapesInsideFrame(IShape shape)
        {
            if (_frame == null)
            {
                return false;
            }
            return _frame.AddShapeInsideFrame(shape);
        }

        /// <summary>
        /// Responsible for resize of shapes inside frame
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="resizeFactor"></param>
        /// <returns></returns>
        public bool ResizeShapesInsideFrame(IShape shape,ResizeFactor resizeFactor)
        {
            if (_frame == null)
            {
                return false;
            }
            return _frame.ResizeShapeInsideFrame(shape,resizeFactor);
        }


        /// <summary>
        /// Responsible for moving shapes inside frame
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="resizeFactor"></param>
        /// <returns></returns>
        public bool MoveShapesInsideFrame(IShape shape, ResizeFactor resizeFactor)
        {
            if (_frame == null)
            {
                return false;
            }
            return _frame.MoveShapeInsideFrame(shape, resizeFactor);
        }

        /// <summary>
        /// Responsible for Drawing shapes which are inside frame.
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public bool DrawShapesInsideFrame(IShape shape)
        {
            if (_frame == null)
            {
                return false;
            }
            return _frame.DrawShapeInsideFrame(shape);
        }
    }
}
