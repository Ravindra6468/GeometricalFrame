using GeometricalFrameLib;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace GeometricalFrameTest
{
    public class CirclesTestLib
    {
        private GeometricalFrameManager _frameManager;
        private Circle _circle;

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
            _circle = null;
        }


        #region Add Circle Tests
        /// <summary>
        /// Valid circle points added without Frame returns false 
        /// </summary>
        [Test]
        public void AddCircleWithoutFrame_WithValidCoordinates_Returns_False()
        {
            //No frame but adding circle
            _frameManager = new GeometricalFrameManager();
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 5);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAdded, false, "Circle Not Added Please check");
        }


        /// <summary>
        /// Valid circle points added with InavlidFrame returns false 
        /// </summary>
        [Test]
        public void AddCircleWithInvalidFrame_WithValidCoordinates_Returns_False()
        {
            _frameManager = new GeometricalFrameManager();
            //invalid frame
            _frameManager.AddFrame(0, 0);
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 5);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAdded, false, "Please check isCircleAdded");
        }

        /// <summary>
        /// Valid circle points added inside Frame. Successfully adds circle
        /// </summary>
        [Test]
        public void AddCircleInFrame_WithValidCoordinates_Returns_True()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 5);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAdded,true,"Circle Not Added Please check");
            Assert.IsNotEmpty(_frameManager.GetFrame().Circles);
            Assert.IsTrue(_frameManager.GetFrame().Circles.Count==1);
        }

        /// <summary>
        /// Valid circle points added inside Frame. Checking for duplicate.Same should not be added again
        /// </summary>
        [Test]
        public void AddCircleInFrame_WithValidCoordinates_AddedAgain()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 5);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            bool isCircleAddedAgain = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAddedAgain, false, "Circle Added Please check for duplicate");
            Assert.IsNotEmpty(_frameManager.GetFrame().Circles);
            Assert.IsTrue(_frameManager.GetFrame().Circles.Count == 1);
        }

        /// <summary>
        /// Valid multiple circle points added inside Frame.Multiple circles added
        /// </summary>
        [Test]
        public void Add_MultipleCircle_InFrameWithValidCoordinates_Returns_True()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 5);
            bool isFirstCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Point secondCirclecenterPoint = new Point(4, -5);
            _circle = new Circle(secondCirclecenterPoint, 3);
            bool isSecondCircleAdded = _frameManager.AddShapesInsideFrame(_circle);

            Assert.AreEqual(isFirstCircleAdded, true, "FirstCircle Not Added Please check");
            Assert.AreEqual(isSecondCircleAdded, true, "SecondCircle Not Added Please check");
            Assert.IsNotEmpty(_frameManager.GetFrame().Circles);
            Assert.IsTrue(_frameManager.GetFrame().Circles.Count == 2);

        }

        /// <summary>
        /// InValid circle points added inside Frame,radius is more Fails
        /// </summary>
        [Test]
        public void AddCircle_InFrameWith_InValidCoordinates_Returns_False()
        {
            Point centerPoint = new Point(15, -5);
            _circle = new Circle(centerPoint, 5);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAdded, false);
        }

        // <summary>
        /// InValid circle points added inside Frame. CenterY point touching Frame y axis fails
        /// </summary>
        [Test]
        public void AddCircleInFrame_With_InvalidYForCircle_CoordinateReturns_False()
        {
            Point centerPoint = new Point(5, -10);
            _circle = new Circle(centerPoint, 5);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frameManager.GetFrame().Circles.Count == 0);
        }

        // <summary>
        /// InValid circle points added inside Frame. CenterX point touching Frame x axis fails
        /// </summary>
        [Test]
        public void AddCircleInFrame_With_InvalidXForCircle_CoordinateReturns_False()
        {
            Point centerPoint = new Point(10, 0);
            _circle = new Circle(centerPoint, 4);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frameManager.GetFrame().Circles.Count == 0);
        }

        // <summary>
        /// InValid circle points added inside Frame. circle center touching  frame origin
        /// </summary>
        [Test]
        public void AddCircleInFrame_With_CircleCenterAsFrameOrigin_Returns_False()
        {
            Point centerPoint = new Point(0, 0);
            _circle = new Circle(centerPoint, 4);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frameManager.GetFrame().Circles.Count == 0);
        }


        // <summary>
        /// Circle outside frame.
        /// </summary>
        [Test]
        public void AddCircleOutSideFrame_Returns_False()
        {
            Point centerPoint = new Point(11, 15);
            _circle = new Circle(centerPoint, 4);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frameManager.GetFrame().Circles.Count == 0);
        }

        // <summary>
        /// Valid circle points added inside Frame.Checking for edge case scenarios
        /// </summary>
        [Test]
        public void AddCircle_ValidCoordinateReturnsTrue_CircleInsideFrameEdgeCase()
        {
            Point centerPoint = new Point(1, -1);
            _circle = new Circle(centerPoint, 0.5);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAdded, true);
            Assert.IsTrue(_frameManager.GetFrame().Circles.Count == 1);
        }


        // <summary>
        /// InValid circle points added inside Frame. Circle with zero radius
        /// </summary>
        [Test]
        public void AddCircleInFrameWithValidCoordinate_CircleWithoutRadius_ReturnsFalse()
        {
            Point centerPoint = new Point(4, -4);
            _circle = new Circle(centerPoint, 0);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frameManager.GetFrame().Circles.Count == 0);
        }


        // <summary>
        /// InValid circle points added inside Frame. Circle with -ve radius
        /// </summary>
        [Test]
        public void AddCircleInFrameWithValidCoordinate_CircleWithoutNegativeRadius_ReturnsFalse()
        {
            Point centerPoint = new Point(4, -4);
            _circle = new Circle(centerPoint, -3);
            bool isCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frameManager.GetFrame().Circles.Count == 0);
        }

        /// <summary>
        /// Valid multiple circle points added inside Frame.In multiple when single circle fails others get added.
        /// </summary>
        [Test]
        public void AddMultipleCircleInFrameWithValidCoordinates_ValidOneCircleAndFailOne()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 5);
            bool isFirstCircleAdded = _frameManager.AddShapesInsideFrame(_circle);
            Point centerPointNew = new Point(4, -5);
            _circle = new Circle(centerPointNew, -3);
            bool isSecondCircleAdded = _frameManager.AddShapesInsideFrame(_circle);

            Assert.AreEqual(isFirstCircleAdded, true, "FirstCircle Not Added");
            Assert.AreEqual(isSecondCircleAdded, false, "SecondCircle Added");
            Assert.IsNotEmpty(_frameManager.GetFrame().Circles);
            Assert.IsTrue(_frameManager.GetFrame().Circles.Count == 1);

        }

        #endregion

        #region Resize Circle Tests

        // <summary>
        /// Valid circle points added inside Frame.Resize Circle ,Retruns true
        /// </summary>
        [Test]
        public void ResizeCircleInFrameWithValidCoordinate__ReturnsTrue()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 3);
            _frameManager.AddShapesInsideFrame(_circle);
            var newRadius = new ResizeFactor(5);
            var isCircleResized = _frameManager.ResizeShapesInsideFrame(_circle, newRadius);
            Assert.AreEqual(isCircleResized, true);
            Assert.IsTrue(_frameManager.GetFrame().Circles.FirstOrDefault(x=>x.Value ==_circle).Value == _circle," Circle Not Resized");
        }


        // <summary>
        /// Valid circle points added inside Frame but invalid radious.Resize Circle ,Retruns false
        /// </summary>
        [Test]
        public void ResizeCircleInFrameWithInValidCoordinate__ReturnsFalse()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 3);
            _frameManager.AddShapesInsideFrame(_circle);
            var newRadius = new ResizeFactor(-5);
            var isCircleResized = _frameManager.ResizeShapesInsideFrame(_circle, newRadius);
            Assert.AreEqual(isCircleResized, false);
            Assert.IsTrue(_frameManager.GetFrame().Circles.FirstOrDefault(x => x.Value == _circle).Value == _circle, " Circle Resized Please check");
        }

        // <summary>
        /// Valid circle points added inside Frame but invalid radious.Resize Circle ,Retruns false
        /// </summary>
        [Test]
        public void ResizeCircleInFrameWithRadiusCrossingFrame__ReturnsFalse()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 3);
            _frameManager.AddShapesInsideFrame(_circle);
            var newRadius = new ResizeFactor(11);
            var isCircleResized = _frameManager.ResizeShapesInsideFrame(_circle, newRadius);
            Assert.AreEqual(isCircleResized, false);
            Assert.IsTrue(_frameManager.GetFrame().Circles.FirstOrDefault(x => x.Value == _circle).Value == _circle, " Circle Resized Please check");
        }

        // <summary>
        /// Valid circle points added inside Frame but invalid radious.Resize Circle ,Retruns false
        /// </summary>
        [Test]
        public void ResizeCircleWithoutCircle__ReturnsFalse()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 3);
            //_frameManager.AddShapesInsideFrame(_circle);
            var newRadius = new ResizeFactor(11);
            var isCircleResized = _frameManager.ResizeShapesInsideFrame(_circle, newRadius);
            Assert.AreEqual(isCircleResized, false);            
        }
        #endregion

        #region Move Circle Tests

        // <summary>
        /// Valid circle points added inside Frame.Resize Circle ,Retruns true
        /// </summary>
        [Test]
        public void MoveCircleInFrameWithValidCoordinate__ReturnsTrue()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 3);
            _frameManager.AddShapesInsideFrame(_circle);
            Point newcenterPoint = new Point(4, -4);
            var newCenter = new ResizeFactor(newcenterPoint);
            var isCircleResized = _frameManager.MoveShapesInsideFrame(_circle, newCenter);
            Assert.AreEqual(isCircleResized, true);
            Assert.IsTrue(_frameManager.GetFrame().Circles.FirstOrDefault(x => x.Value == _circle).Value == _circle, " Circle Not Resized");
        }


        // <summary>
        /// Valid circle points added inside Frame.Move Circle,outside frame ,Retruns False
        /// </summary>
        [Test]
        public void MoveCircleInFrameWithValidCoordinate__ReturnsFalse()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 3);
            _frameManager.AddShapesInsideFrame(_circle);
            Point newcenterPoint = new Point(14, -4);
            var newCenter = new ResizeFactor(newcenterPoint);
            var isCircleResized = _frameManager.MoveShapesInsideFrame(_circle, newCenter);
            Assert.AreEqual(isCircleResized, false);
            Assert.IsTrue(_frameManager.GetFrame().Circles.FirstOrDefault(x => x.Value == _circle).Value == _circle, " Circle Not Resized");
        }

        // <summary>
        /// Valid circle points added inside Frame.Move Circle,crosses frame ,Retruns False
        /// </summary>
        [Test]
        public void MoveCircleInFrameWithValidCoordinateCrossesFrame__ReturnsFalse()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 3);
            _frameManager.AddShapesInsideFrame(_circle);
            Point newcenterPoint = new Point(8, -8);
            var newCenter = new ResizeFactor(newcenterPoint);
            var isCircleResized = _frameManager.MoveShapesInsideFrame(_circle, newCenter);
            Assert.AreEqual(isCircleResized, false);
            Assert.IsTrue(_frameManager.GetFrame().Circles.FirstOrDefault(x => x.Value == _circle).Value == _circle, " Circle Not Resized");
        }


        #endregion

        #region Draw Circle Tests

        // <summary>
        /// Draw circle with valid circle 
        /// </summary>
        [Test]
        public void DrawCircleInFrameWithValidCoordinate__ReturnsTrue()
        {
            Point centerPoint = new Point(5, -5);
            _circle = new Circle(centerPoint, 3);
            _frameManager.AddShapesInsideFrame(_circle);
            var isCircleDrwaninConsole = _frameManager.DrawShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleDrwaninConsole, true);
            
        }

        // <summary>
        /// Draw circle with without adding circle 
        /// </summary>
        [Test]
        public void DrawCircleInFrameWithInValidCircle__ReturnsFalse()
        {
            var isCircleDrwaninConsole = _frameManager.DrawShapesInsideFrame(_circle);
            Assert.AreEqual(isCircleDrwaninConsole, false);

        }

        #endregion
    }
}