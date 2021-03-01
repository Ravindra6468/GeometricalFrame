using GeometricalFrameLib;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace GeometricalFrameTest
{
    public class RectangleTestLib
    {
        private GeometricalFrameManager _frameManager;
        private Rectangle _rectangle;

        [SetUp]
        public void Setup()
        {
            _frameManager = new GeometricalFrameManager();
            _frameManager.AddFrame(10, -10);

        }

        [TearDown]
        public void CleanUp()
        {
            _frameManager = null;
            _rectangle = null;
        }


        #region Add Rectangle Tests
        /// <summary>
        /// valid rectangle without frame
        /// </summary>
        [Test]
        public void AddRectangleWithoutFrame_WithValidCoordinates_Returns_False()
        {
            //No frame but adding rectangle
            _frameManager = new GeometricalFrameManager();
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4,3);
            bool isRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleAdded, false, "Rectangle Not Added Please check");
        }


        /// <summary>
        /// Valid rectangle points added with InavlidFrame returns false 
        /// </summary>
        [Test]
        public void AddRectangleWithInvalidFrame_WithValidCoordinates_Returns_False()
        {
            _frameManager = new GeometricalFrameManager();
            //invalid frame
            _frameManager.AddFrame(0, 0);
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            bool isRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleAdded, false, "Please check isRectangleAdded");
        }

        /// <summary>
        /// Valid rectangle points added inside Frame. Successfully adds rectangle
        /// </summary>
        [Test]
        public void AddRectangleInFrame_WithValidCoordinates_Returns_True()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            bool isRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleAdded,true,"Rectangle Not Added Please check");
            Assert.IsNotEmpty(_frameManager.GetFrame().Rectangles);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.Count==1);
        }

        /// <summary>
        /// Valid Rectangle points added inside Frame. Checking for duplicate.Same should not be added again
        /// </summary>
        [Test]
        public void AddRectangleInFrame_WithValidCoordinates_AddedAgain()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            bool isRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            bool isRectangleAddedAgain = _frameManager.AddShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleAddedAgain, false, "Rectangle Added Please check for duplicate");
            Assert.IsNotEmpty(_frameManager.GetFrame().Rectangles);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.Count == 1);
        }

        /// <summary>
        /// Valid multiple Rectangle points added inside Frame.Multiple Rectangles added
        /// </summary>
        [Test]
        public void Add_MultipleRectangle_InFrameWithValidCoordinates_Returns_True()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            bool isFirstRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Point secondRectangleOriginPoint = new Point(4, -5);
            _rectangle = new Rectangle(secondRectangleOriginPoint, 3,5);
            bool isSecondRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);

            Assert.AreEqual(isFirstRectangleAdded, true, "FirstRectangle Not Added Please check");
            Assert.AreEqual(isSecondRectangleAdded, true, "SecondRectangle Not Added Please check");
            Assert.IsNotEmpty(_frameManager.GetFrame().Rectangles);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.Count == 2);

        }

        /// <summary>
        /// InValid Rectangle points added inside Frame,radius is more Fails
        /// </summary>
        [Test]
        public void AddRectangle_InFrameWith_InValidCoordinates_Returns_False()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 6, 6);
            bool isRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleAdded, false);
        }

        // <summary>
        /// InValid Rectangle points added inside Frame
        /// </summary>
        [Test]
        public void AddRectangleInFrame_With_InvalidYForRectangle_CoordinateReturns_False()
        {
            Point originPoint = new Point(0, -5);
            _rectangle = new Rectangle(originPoint, 0, 3);
            bool isRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleAdded, false);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.Count == 0);
        }

        // <summary>
        /// InValid Rectangle points added inside Frame. 
        /// </summary>
        [Test]
        public void AddRectangleInFrame_With_InvalidXForRectangle_CoordinateReturns_False()
        {
            Point originPoint = new Point(0, 0);
            _rectangle = new Rectangle(originPoint, 0, 0);
            bool isRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleAdded, false);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.Count == 0);
        }

        // <summary>
        /// InValid Rectangle points added inside Frame. Rectangle origin outside  frame origin
        /// </summary>
        [Test]
        public void AddRectangleInFrame_With_RectangleCenterAsFrameOrigin_Returns_False()
        {
            Point originPoint = new Point(-5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            bool isRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleAdded, false);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.Count == 0);
        }


        // <summary>
        /// Valid Rectangle points added inside Frame.Checking for edge case scenarios
        /// </summary>
        [Test]
        public void AddRectangle_ValidCoordinateReturnsTrue_RectangleInsideFrameEdgeCase()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 5, 5);
            bool isRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleAdded, true);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.Count == 1);
        }


        // <summary>
        /// InValid Rectangle points added inside Frame. -ve height
        /// </summary>
        [Test]
        public void AddRectangleInFrameWithValidCoordinate_RectangleWithoutRadius_ReturnsFalse()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, -3);
            bool isRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleAdded, false);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.Count == 0);
        }


        // <summary>
        /// InValid Rectangle points added inside Frame. Rectangle with -ve width
        /// </summary>
        [Test]
        public void AddRectangleInFrameWithValidCoordinate_RectangleWithoutNegativeRadius_ReturnsFalse()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, -4, 3);
            bool isRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleAdded, false);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.Count == 0);
        }

        /// <summary>
        /// Valid multiple Rectangle points added inside Frame.In multiple when single Rectangle fails others get added.
        /// </summary>
        [Test]
        public void AddMultipleRectangleInFrameWithValidCoordinates_ValidOneRectangleAndFailOne()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, -3);
            bool isFirstRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);
            Point originPoint1 = new Point(5, -5);
            _rectangle = new Rectangle(originPoint1, 4, 3);
            bool isSecondRectangleAdded = _frameManager.AddShapesInsideFrame(_rectangle);

            Assert.AreEqual(isFirstRectangleAdded, false, "FirstRectangle Not Added");
            Assert.AreEqual(isSecondRectangleAdded, true, "SecondRectangle Added");
            Assert.IsNotEmpty(_frameManager.GetFrame().Rectangles);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.Count == 1);

        }

        #endregion

        #region Resize Rectangle Tests

        // <summary>
        /// Valid Rectangle points added inside Frame.Resize Rectangle ,Retruns true
        /// </summary>
        [Test]
        public void ResizeRectangleInFrameWithValidCoordinate__ReturnsTrue()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            _frameManager.AddShapesInsideFrame(_rectangle);

            var _newHeightandWidth = new ResizeFactor(3,3);
            var isRectangleResized = _frameManager.ResizeShapesInsideFrame(_rectangle, _newHeightandWidth);
            Assert.AreEqual(isRectangleResized, true);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.FirstOrDefault(x=>x.Value ==_rectangle).Value == _rectangle," Rectangle Not Resized");
        }


        // <summary>
        /// Valid Rectangle points added inside Frame.Resize Rectangle ,edge cases Retruns true
        /// </summary>
        [Test]
        public void ResizeRectangleInFrameWithValidCoordinateEdgecase__ReturnsTrue()
        {
            Point originPoint = new Point(7, -7);
            _rectangle = new Rectangle(originPoint, 1, 1);
            _frameManager.AddShapesInsideFrame(_rectangle);

            var _newHeightandWidth = new ResizeFactor(3, 3);
            var isRectangleResized = _frameManager.ResizeShapesInsideFrame(_rectangle, _newHeightandWidth);
            Assert.AreEqual(isRectangleResized, true);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.FirstOrDefault(x => x.Value == _rectangle).Value == _rectangle, " Rectangle Not Resized");
        }

        // <summary>
        /// Valid Rectangle points added inside Frame but invalid height and width ,Retruns false
        /// </summary>
        [Test]
        public void ResizeRectangleInFrameWithInValidCoordinate__ReturnsFalse()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            _frameManager.AddShapesInsideFrame(_rectangle);
            var newHeightandWidth = new ResizeFactor(5,-5);
            var isRectangleResized = _frameManager.ResizeShapesInsideFrame(_rectangle, newHeightandWidth);
            Assert.AreEqual(isRectangleResized, false);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.FirstOrDefault(x => x.Value == _rectangle).Value == _rectangle, " Rectangle Resized Please check");
        }


        // <summary>
        /// Valid Rectangle points added inside Frame but invalid width ,Retruns false
        /// </summary>
        [Test]
        public void ResizeRectangleInFrameWithInvalidWidth__ReturnsFalse()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            _frameManager.AddShapesInsideFrame(_rectangle);
            _frameManager = new GeometricalFrameManager();
            var newHeightandWidth = new ResizeFactor(-5, 5);
            var isRectangleResized = _frameManager.ResizeShapesInsideFrame(_rectangle, newHeightandWidth);
            Assert.AreEqual(isRectangleResized, false);

        }

        // <summary>
        /// Valid Rectangle points added inside Frame but With Extra Height CrossingFrame,Retruns false
        /// </summary>
        [Test]
        public void ResizeRectangleInFrameWithExtraHeightaCrossingFrame__ReturnsFalse()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 5, 5);
            _frameManager.AddShapesInsideFrame(_rectangle);
            _frameManager = new GeometricalFrameManager();
            var newHeightandWidth = new ResizeFactor(5, 10);
            var isRectangleResized = _frameManager.ResizeShapesInsideFrame(_rectangle, newHeightandWidth);
            Assert.AreEqual(isRectangleResized, false);

        }

        // <summary>
        /// Valid Rectangle points added inside Frame but With Extra Height CrossingFrame,Retruns false
        /// </summary>
        [Test]
        public void ResizeRectangleInFrameWithExtraWidthtaCrossingFrame__ReturnsFalse()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 5, 5);
            _frameManager.AddShapesInsideFrame(_rectangle);
            _frameManager = new GeometricalFrameManager();
            var newHeightandWidth = new ResizeFactor(10, 5);
            var isRectangleResized = _frameManager.ResizeShapesInsideFrame(_rectangle, newHeightandWidth);
            Assert.AreEqual(isRectangleResized, false);

        }

        // <summary>
        /// Valid Rectangle points added inside Frame but invalid frame ,Retruns false
        /// </summary>
        [Test]
        public void ResizeRectangleInFrameWithNoFrame__ReturnsFalse()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            _frameManager.AddShapesInsideFrame(_rectangle);
            _frameManager = new GeometricalFrameManager();
            var newHeightandWidth = new ResizeFactor(5, 5);
            var isRectangleResized = _frameManager.ResizeShapesInsideFrame(_rectangle, newHeightandWidth);
            Assert.AreEqual(isRectangleResized, false);
            
        }

        #endregion

        #region Move Rectangle Tests

        // <summary>
        /// Valid Rectangle points added inside Frame.Move Rectangle inside frame ,Retruns true
        /// </summary>
        [Test]
        public void MoveRectangleInFrameWithValidCoordinate__ReturnsTrue()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            _frameManager.AddShapesInsideFrame(_rectangle);
            Point newOrigin = new Point(3, -4);
            var _resizeFactor = new ResizeFactor(newOrigin);
            var isRectangleMoved = _frameManager.MoveShapesInsideFrame(_rectangle, _resizeFactor);
            Assert.AreEqual(isRectangleMoved, true);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.FirstOrDefault(x => x.Value == _rectangle).Value == _rectangle, " Rectangle Not Resized");
        }

        // <summary>
        /// Valid Rectangle points added inside Frame.Move Rectangle inside frame,Edge case ,Retruns true
        /// </summary>
        [Test]
        public void MoveRectangleInFrameWithValidCoordinateEdgeCase__ReturnsTrue()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 1, 1);
            _frameManager.AddShapesInsideFrame(_rectangle);
            Point newOrigin = new Point(9, -9);
            var _resizeFactor = new ResizeFactor(newOrigin);
            var isRectangleMoved = _frameManager.MoveShapesInsideFrame(_rectangle, _resizeFactor);
            Assert.AreEqual(isRectangleMoved, true);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.FirstOrDefault(x => x.Value == _rectangle).Value == _rectangle, " Rectangle Not Resized");
        }


        // <summary>
        /// Valid Rectangle points added inside Frame.Move Rectangle,outside frame ,Retruns False
        /// </summary>
        [Test]
        public void MoveRectangleInFrameWithValidCoordinate__ReturnsFalse()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            _frameManager.AddShapesInsideFrame(_rectangle);
            Point newcenterPoint = new Point(14, -4);
            var _resizeFactor = new ResizeFactor(newcenterPoint);
            var isRectangleMoved = _frameManager.MoveShapesInsideFrame(_rectangle, _resizeFactor);
            Assert.AreEqual(isRectangleMoved, false);
            Assert.IsTrue(_frameManager.GetFrame().Rectangles.FirstOrDefault(x => x.Value == _rectangle).Value == _rectangle, " Rectangle Not Resized");
        }


        #endregion

        #region Draw Rectangle Tests

        // <summary>
        /// Draw Rectangle with valid Rectangle 
        /// </summary>
        [Test]
        public void DrawRectangleInFrameWithValidCoordinate__ReturnsTrue()
        {
            Point originPoint = new Point(5, -5);
            _rectangle = new Rectangle(originPoint, 4, 3);
            _frameManager.AddShapesInsideFrame(_rectangle);
            var isRectangleDrwaninConsole = _frameManager.DrawShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleDrwaninConsole, true);
            
        }

        // <summary>
        /// Draw Rectangle with without adding Rectangle 
        /// </summary>
        [Test]
        public void DrawRectangleInFrameWithInValidRectangle__ReturnsFalse()
        {
            var isRectangleDrwaninConsole = _frameManager.DrawShapesInsideFrame(_rectangle);
            Assert.AreEqual(isRectangleDrwaninConsole, false);

        }

        #endregion
    }
}