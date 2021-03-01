using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricalFrameLib
{
    public interface IShape
    {
        public void MoveShape(Point centreMoveToPoint);
        public void ResizeShape(double resizeFactor);
        public void ResizeShape(Point resizeFactor);
        public void DrawShape();
    }
}
