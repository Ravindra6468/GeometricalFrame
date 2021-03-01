using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricalFrameLib
{
    public class GeometricalFrameManager
    {
        private Frame _frame;

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
               _frame = new Frame(length, width);
                _frame.FrameAdded = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Frame GetFrame()
        {
            return _frame;
        }

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

        public bool AddShapesInsideFrame(IShape shape)
        {
            if (_frame == null)
            {
                return false;
            }
            return _frame.AddShapeInsideFrame(shape);
        }

        public bool ResizeShapesInsideFrame(IShape shape,ResizeFactor resizeFactor)
        {
            if (_frame == null)
            {
                return false;
            }
            return _frame.ResizeShapeInsideFrame(shape,resizeFactor);
        }

        public bool MoveShapesInsideFrame(IShape shape, ResizeFactor resizeFactor)
        {
            if (_frame == null)
            {
                return false;
            }
            return _frame.MoveShapeInsideFrame(shape, resizeFactor);
        }

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
