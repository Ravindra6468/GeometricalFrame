using GeometricalFrameLib;
using Moq;
using NUnit.Framework;
using System;

namespace GeometricalFrameTest
{
    public class CirclesTestLib
    {
        private GeometricalFrame _frame;
        private IShape _shape;

        [SetUp]
        public void Setup()
        {
            _frame = new GeometricalFrame();
        }

        [TearDown]
        public void CleanUp()
        {
            _frame = null;
            _shape = null;
        }

        /// <summary>
        /// Valid circle points added without Frame returns false 
        /// </summary>
        [Test]
        public void AddCircleWithoutFrame_WithValidCoordinates_Returns_False()
        {
            //No frame but adding circle
            _shape = new Circle(new Point(5,-5), 5);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAdded, false, "Circle Not Added Please check");
            Assert.IsEmpty(_frame.Shapes);
            Assert.IsTrue(_frame.Shapes.Count == 0);
        }


        /// <summary>
        /// Valid circle points added with InavlidFrame returns false 
        /// </summary>
        [Test]
        public void AddCircleWithInvalidFrame_WithValidCoordinates_Returns_False()
        {
            _frame.AddFrame(10, 10);
            _shape = new Circle(new Point(5, -5), 5);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAdded, false, "Circle Not Added Please check");
            Assert.IsEmpty(_frame.Shapes);
            Assert.IsTrue(_frame.Shapes.Count == 0);
        }

        /// <summary>
        /// Valid circle points added inside Frame. Successfully adds circle
        /// </summary>
        [Test]
        public void AddCircleInFrame_WithValidCoordinates_Returns_True()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(5, -5), 5);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAdded,true,"Circle Not Added Please check");
            Assert.IsNotEmpty(_frame.Shapes);
            Assert.IsTrue(_frame.Shapes.Count==1);
        }

        /// <summary>
        /// Valid circle points added inside Frame. Checking for duplicate.Same should not be added again
        /// </summary>
        [Test]
        public void AddCircleInFrame_WithValidCoordinates_AddedAgain()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(5, -5), 5);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            bool isCircleAddedAgain = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAddedAgain, false, "Circle Added Please check for duplicate");
            Assert.IsNotEmpty(_frame.Shapes);
            Assert.IsTrue(_frame.Shapes.Count == 1);
        }

        /// <summary>
        /// Valid multiple circle points added inside Frame.Multiple circles added
        /// </summary>
        [Test]
        public void Add_MultipleCircle_InFrameWithValidCoordinates_Returns_True()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(5, -5), 5);
            bool isFirstCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            _shape = new Circle(new Point(4, -5), 3);
            bool isSecondCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);

            Assert.AreEqual(isFirstCircleAdded, true, "FirstCircle Not Added Please check");
            Assert.AreEqual(isSecondCircleAdded, true, "SecondCircle Not Added Please check");
            Assert.IsNotEmpty(_frame.Shapes);
            Assert.IsTrue(_frame.Shapes.Count == 2);

        }

        /// <summary>
        /// InValid circle points added inside Frame,radius is more Fails
        /// </summary>
        [Test]
        public void AddCircle_InFrameWith_InValidCoordinates_Returns_False()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(5, -5), 10);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frame.Shapes.Count ==0);
        }

        // <summary>
        /// InValid circle points added inside Frame. CenterY point touching Frame y axis fails
        /// </summary>
        [Test]
        public void AddCircleInFrame_With_InvalidYForCircle_CoordinateReturns_False()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(5, -10), 4);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frame.Shapes.Count == 0);
        }

        // <summary>
        /// InValid circle points added inside Frame. CenterX point touching Frame x axis fails
        /// </summary>
        [Test]
        public void AddCircleInFrame_With_InvalidXForCircle_CoordinateReturns_False()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(-5, -5), 4);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frame.Shapes.Count == 0);
        }

        // <summary>
        /// InValid circle points added inside Frame. circle center touching  frame origin
        /// </summary>
        [Test]
        public void AddCircleInFrame_With_CircleCenterAsFrameOrigin_Returns_False()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(10, 0), 4);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frame.Shapes.Count == 0);
        }


        // <summary>
        /// Circle outside frame.
        /// </summary>
        [Test]
        public void AddCircleOutSideFrame_Returns_False()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(11, 15), 4);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frame.Shapes.Count == 0);
        }

        // <summary>
        /// Valid circle points added inside Frame.Checking for edge case scenarios
        /// </summary>
        [Test]
        public void AddCircle_ValidCoordinateReturnsTrue_CircleInsideFrameEdgeCase()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(1, -1), .5);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAdded, true);
            Assert.IsTrue(_frame.Shapes.Count == 1);
        }


        // <summary>
        /// InValid circle points added inside Frame. Circle with zero radius
        /// </summary>
        [Test]
        public void AddCircleInFrameWithValidCoordinate_CircleWithoutRadius_ReturnsFalse()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(4, -4), 0);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frame.Shapes.Count == 0);
        }


        // <summary>
        /// InValid circle points added inside Frame. Circle with -ve radius
        /// </summary>
        [Test]
        public void AddCircleInFrameWithValidCoordinate_CircleWithoutNegativeRadius_ReturnsFalse()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(4, -4), -3);
            bool isCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            Assert.AreEqual(isCircleAdded, false);
            Assert.IsTrue(_frame.Shapes.Count == 0);
        }

        /// <summary>
        /// Valid multiple circle points added inside Frame.In multiple when single circle fails others get added.
        /// </summary>
        [Test]
        public void AddMultipleCircleInFrameWithValidCoordinates_ValidOneCircleAndFailOne()
        {
            _frame.AddFrame(10, -10);
            _shape = new Circle(new Point(5, -5), 5);
            bool isFirstCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);
            _shape = new Circle(new Point(5, -4), -3);
            bool isSecondCircleAdded = _frame.AddBasicShapesInsideFrame(_shape);

            Assert.AreEqual(isFirstCircleAdded, true, "FirstCircle Not Added");
            Assert.AreEqual(isSecondCircleAdded, false, "SecondCircle Added");
            Assert.IsNotEmpty(_frame.Shapes);
            Assert.IsTrue(_frame.Shapes.Count == 1);

        }

    }
}