using GeometricalFrameLib;
using Moq;
using NUnit.Framework;
using System;

namespace GeometricalFrameTest
{
    /// <summary>
    /// This class verifies the given coordinates will construct a frame 
    /// in 4th quadrant in the Geometrical frame or not based on the requirement
    /// </summary>
    public class GeometricalFrameLibTest
    {

        private GeometricalFrame _geometricalFrame;

        /// <summary>
        /// Test setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _geometricalFrame = new GeometricalFrame();
        }


        /// <summary>
        /// Tear down calls after each method to reset test data
        /// </summary>
        [TearDown]
        public void CleanUp()
        {
            _geometricalFrame = null;
        }


        /// <summary>
        /// Valid Input Frame will be added
        /// </summary>
        [Test]
        public void AddFrameWithValidCoordinates()
        {
            bool frameAdded = _geometricalFrame.AddFrame(10, -10);
            Assert.AreEqual(frameAdded, true);
        }

        /// <summary>
        /// Valid decimal point Input Frame will be added
        /// </summary>
        [Test]
        public void AddFrameWithValidDecimalCoordinates()
        {
            bool frameAdded = _geometricalFrame.AddFrame(20.5, -10.5);
            Assert.AreEqual(frameAdded, true);
        }

        /// <summary>
        /// Valid decimal point Input Frame will be added
        /// </summary>
        [Test]
        public void AddFrameWithValidMinimalDecimalCoordinates()
        {
            bool frameAdded = _geometricalFrame.AddFrame(.5, -.6);
            Assert.AreEqual(frameAdded, true);
        }

        /// <summary>
        /// InValid  Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithInvalidCoordinates()
        {
            bool actualResult = _geometricalFrame.AddFrame(-10, -10);
            Assert.AreEqual(actualResult, false);
        }

        /// <summary>
        /// InValid decimal point Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithInvalidDecimalCoordinates()
        {
            bool actualResult = _geometricalFrame.AddFrame(-10.8, -20.5);
            Assert.AreEqual(actualResult, false);
        }

        /// <summary>
        /// InValid decimal point Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithInValidCoordinatesReturnsFalse()
        {
            bool frameAdded = _geometricalFrame.AddFrame(0, 0);
            Assert.AreEqual(frameAdded, false);
        }


        /// <summary>
        /// InValid decimal point Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithInValidCoordinates_NegativePositive_ReturnsFalse()
        {
            bool frameAdded = _geometricalFrame.AddFrame(-10,10);
            Assert.AreEqual(frameAdded, false);
        }

        /// <summary>
        /// InValid decimal point Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithValidCoordinatesDuplicateCheckReturnsFalse()
        {
            bool frameAdded = _geometricalFrame.AddFrame(15, -15);
            Assert.AreEqual(frameAdded, true);

            //Try to add duplicate frame returns false
            bool duplicateframeAdded = _geometricalFrame.AddFrame(15, -15);
            Assert.AreEqual(duplicateframeAdded, false);
        }

        /// <summary>
        /// InValid decimal point Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithValidCoordinatesDecimalDuplicateCheckReturnsFalse()
        {
            bool frameAdded = _geometricalFrame.AddFrame(35.5, -15);
            Assert.AreEqual(frameAdded, true);

            //Try to add duplicate frame returns false
            bool duplicateframeAdded = _geometricalFrame.AddFrame(15.0, -15.0);
            Assert.AreEqual(duplicateframeAdded, false);
        }

        /// <summary>
        /// Valid t Input Frame will be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithValidCoordinates()
        {
            _geometricalFrame.FrameAdded = true;
            bool frameModified = _geometricalFrame.ModifyFrame(10, -10);
            Assert.AreEqual(frameModified, true);
        }

        /// <summary>
        /// Valid t Input Frame will be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithValidDecimalCoordinatesReturnsTrue()
        {
            _geometricalFrame.FrameAdded = true;
            bool frameModified = _geometricalFrame.ModifyFrame(50.7, -40.2);
            Assert.AreEqual(frameModified, true);
        }

        /// <summary>
        /// Invalid  Input Frame will not be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithInValid_DecimalCoordinates()
        {
            _geometricalFrame.FrameAdded = true;
            bool frameModified = _geometricalFrame.ModifyFrame(0, 0);
            Assert.AreEqual(frameModified, false);
        }

        /// <summary>
        /// Invalid  Input Frame will not be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithValidDecimalCoordinates()
        {
            _geometricalFrame.FrameAdded = true;
            bool frameModified = _geometricalFrame.ModifyFrame(13.5, -10);
            Assert.AreEqual(frameModified, true);
        }

        /// <summary>
        /// Invalid  Input Frame will not be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithInvalidCoordinates()
        {
            _geometricalFrame.FrameAdded = true;
            bool frameModified = _geometricalFrame.ModifyFrame(-10, -10);
            Assert.AreEqual(frameModified, false);
        }

        /// <summary>
        /// Invalid  Input Frame will not be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithInValidCoordinatesReturnsFalse()
        {
            _geometricalFrame.FrameAdded = true;
            bool frameModified = _geometricalFrame.ModifyFrame(.7, 0);
            Assert.AreEqual(frameModified, false);
        }

        /// <summary>
        /// Invalid  Input Frame will not be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithInValidCoordinates_NegativePositive_ReturnsFalse()
        {
            _geometricalFrame.FrameAdded = true;
            bool frameModified = _geometricalFrame.ModifyFrame(-10, 10);
            Assert.AreEqual(frameModified, false);
        }






    }
}