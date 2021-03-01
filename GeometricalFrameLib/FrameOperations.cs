using System;
using System.Collections.Generic;
using System.Linq;

namespace GeometricalFrameLib
{
    /// <summary>
    /// This class will be responsible for operations inside frame.
    /// </summary>
    public class FrameOperations 
    {
        #region Public variables

        /// <summary>
        /// Represents x-Axis
        /// </summary>
        public double XCord { get; set; }
        /// <summary>
        /// Minimum x needed to draw shapes
        /// </summary>       
        public double Xmin { get; set; }

        /// <summary>
        /// Represents y-Axis
        /// </summary>
        public double YCord { get; set; }

        /// <summary>
        /// Minimum y needed to draw shapes
        /// </summary>         
        public double Ymin { get; set; }

        /// <summary>
        /// To check frame already present or not
        /// </summary>
        public bool FrameAdded { get; set; }

        /// <summary>
        /// To maintain list of circles inside frame
        /// </summary>
        public Dictionary<int, IShape> Circles { get; set; }

        /// <summary>
        /// To maintain list of rectangles inside frame
        /// </summary>
        public Dictionary<int, IShape> Rectangles { get; set; }

        #endregion

        #region Constructor
        public FrameOperations(double length, double width)
        {
            this.XCord = length;
            this.YCord = width;
            FrameAdded = true;
            Xmin = Ymin = 0;
            Circles = new Dictionary<int, IShape>();
            Rectangles = new Dictionary<int, IShape>();
        }


        #endregion

        #region Public methods

        public bool ModifyFrame(double length, double width)
        {
            if (FrameAdded && length > 0 && width < 0 && length >= Xmin && width <= Ymin)
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
        public bool AddShapeInsideFrame(IShape shape)
        {

            if (shape as Circle != null)
            {
                var circle = shape as Circle;
                if (Circles.ContainsValue(circle))
                {
                    return false;
                }
                //If circle has valid cords and falls inside frame then only add it
                if (IsValidPosition(circle))
                {
                    Circles.Add(Circles.Count, circle);
                    return true;
                }

                return false;
            }

            else if (shape as Rectangle != null)
            {
                var rectangle = shape as Rectangle;
                if (Rectangles.ContainsValue(rectangle))
                {
                    return false;
                }
                //If circle has valid cords and falls inside frame then only add it
                if (IsValidPosition(rectangle))
                {
                    Rectangles.Add(Rectangles.Count, rectangle);
                    return true;
                }

                return false;
            }
            
            return false;
        }

        /// <summary>
        /// Adding Circles inside given frame
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public bool ResizeShapeInsideFrame(IShape shape, ResizeFactor resizeFactor)
        {

            if (shape as Circle != null)
            {
                var circle = shape as Circle;

                //Only If same circle is present we can resize
                if (Circles.ContainsValue(circle))
                {
                    var circleTobeResized = new Circle(circle.centerPoint, resizeFactor.Radius);

                    //check new radious fits inside frame then resize
                    if (IsValidPosition(circleTobeResized))
                    {
                        var newCircle = Circles.FirstOrDefault(x => x.Value == circle).Value;
                        newCircle.ResizeShape(resizeFactor.Radius);
                        return true;
                    }                  
                }
            }

            else if (shape as Rectangle != null)
            {
                var rectangle = shape as Rectangle;

                //Only If same circle is present we can resize
                if (Rectangles.ContainsValue(rectangle))
                {
                    var rectangleTobeResized = new Rectangle(rectangle.Origin, resizeFactor.NewValue.x,resizeFactor.NewValue.y);

                    //check new radious fits inside frame then resize
                    if (IsValidPosition(rectangleTobeResized))
                    {
                        var newRectangle = Rectangles.FirstOrDefault(x => x.Value == rectangle).Value;
                        newRectangle.ResizeShape(resizeFactor.NewValue);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Adding Circles inside given frame
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public bool MoveShapeInsideFrame(IShape shape, ResizeFactor resizeFactor)
        {

            if (shape as Circle != null)
            {
                var circle = shape as Circle;

                //Only If same circle is present we can resize
                if (Circles.ContainsValue(circle))
                {
                    var circleTobeMoved = new Circle(resizeFactor.NewValue, circle.Radius);

                    //check new radious fits inside frame then resize
                    if (IsValidPosition(circleTobeMoved))
                    {
                        var newCircle = Circles.FirstOrDefault(x => x.Value == circle).Value;
                        newCircle.MoveShape(resizeFactor.NewValue);
                        return true;
                    }
                }
            }

            else if (shape as Rectangle != null)
            {
                var rectangle = shape as Rectangle;

                //Only If same circle is present we can resize
                if (Rectangles.ContainsValue(rectangle))
                {
                    var rectangleTobeMoved = new Rectangle(resizeFactor.NewValue, rectangle.Width,rectangle.Height);

                    //check new radious fits inside frame then resize
                    if (IsValidPosition(rectangleTobeMoved))
                    {
                        var newCircle = Rectangles.FirstOrDefault(x => x.Value == rectangle).Value;
                        newCircle.MoveShape(resizeFactor.NewValue);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Adding Circles inside given frame
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public bool DrawShapeInsideFrame(IShape shape)
        {

            if (shape as Circle != null)
            {
                var circle = shape as Circle;

                //Only If same circle is present we can resize
                if (Circles.ContainsValue(circle))
                {
                    circle.DrawShape();
                    return true;
                }
            }

            else if (shape as Rectangle != null)
            {
                var rectangle = shape as Rectangle;

                //Only If same circle is present we can resize
                if (Rectangles.ContainsValue(rectangle))
                {
                    rectangle.DrawShape();
                    return true;
                }
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
        private bool IsValidPosition(IShape shape)
        {
            //Circle
            if (shape as Circle != null)
            {
                var circle = shape as Circle;
                //No frame added
                if (!FrameAdded)
                {
                    return false;
                }

                //Invalid circle inputs for Quadrant 4
                if (circle.centerPoint.x < 0 || circle.centerPoint.y > 0 || circle.Radius <= 0)
                {
                    return false;
                }

                //Circle will cross frame, Circle center outside frame
                if (circle.centerPoint.x >= XCord || circle.centerPoint.y <= YCord)
                {
                    return false;
                }

                //Circle will cross frame, Radius is more than Frame dimension
                if (circle.Radius > circle.centerPoint.x || circle.Radius < circle.centerPoint.y)
                {
                    return false;
                }

                //Circle will cross the frame. Circle center near to frame borders
                if ((circle.centerPoint.x + circle.Radius > XCord) || (circle.centerPoint.y + (circle.Radius * -1)) < YCord)
                {
                    return false;
                }

                //valid circle inputs
                return true;
            }

            //Rectangle
            if(shape as Rectangle != null)
            {
                var rectangle = shape as Rectangle;
                //No frame added
                if (!FrameAdded)
                {
                    return false;
                }

                //Invalid rectangle inputs for Quadrant 4
                if (rectangle.Origin.x < 0 || rectangle.Origin.y > 0 || rectangle.Height <= 0 || rectangle.Width <= 0)
                {
                    return false;
                }

                //rectangle will cross frame, rectangle origin outside frame
                if (rectangle.Origin.x >= XCord || rectangle.Origin.y <= YCord)
                {
                    return false;
                }


                //Rectagle will cross the frame. Rectagle origin near to frame borders
                if ((rectangle.Origin.x + rectangle.Width > XCord ) || (rectangle.Origin.y + rectangle.Height < YCord || (rectangle.Origin.y + rectangle.Height > 0)))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

    }
}
