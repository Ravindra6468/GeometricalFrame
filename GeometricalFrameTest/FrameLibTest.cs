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
    public class FrameLibTest
    {

        private GeometricalFrameManager _geometricalFrameManager;

        /// <summary>
        /// Test setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _geometricalFrameManager = new GeometricalFrameManager();
        }


        /// <summary>
        /// Tear down calls after each method to reset test data
        /// </summary>
        [TearDown]
        public void CleanUp()
        {
            _geometricalFrameManager = null;
        }


        /// <summary>
        /// Valid Input Frame will be added
        /// </summary>
        [Test]
        public void AddFrameWithValidCoordinates()
        {
            bool frameAdded = _geometricalFrameManager.AddFrame(10, -10);
            Assert.AreEqual(frameAdded, true);
        }

        /// <summary>
        /// Valid decimal point Input Frame will be added
        /// </summary>
        [Test]
        public void AddFrameWithValidDecimalCoordinates()
        {
            bool frameAdded = _geometricalFrameManager.AddFrame(20.5, -10.5);
            Assert.AreEqual(frameAdded, true);
        }

        /// <summary>
        /// Valid decimal point Input Frame will be added
        /// </summary>
        [Test]
        public void AddFrameWithValidMinimalDecimalCoordinates()
        {
            bool frameAdded = _geometricalFrameManager.AddFrame(.5, -.6);
            Assert.AreEqual(frameAdded, true);
        }

        /// <summary>
        /// InValid  Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithInvalidCoordinates()
        {
            bool actualResult = _geometricalFrameManager.AddFrame(-10, -10);
            Assert.AreEqual(actualResult, false);
        }

        /// <summary>
        /// InValid decimal point Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithInvalidDecimalCoordinates()
        {
            bool actualResult = _geometricalFrameManager.AddFrame(-10.8, -20.5);
            Assert.AreEqual(actualResult, false);
        }

        /// <summary>
        /// InValid decimal point Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithInValidCoordinatesReturnsFalse()
        {
            bool frameAdded = _geometricalFrameManager.AddFrame(0, 0);
            Assert.AreEqual(frameAdded, false);
        }


        /// <summary>
        /// InValid decimal point Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithInValidCoordinates_NegativePositive_ReturnsFalse()
        {
            bool frameAdded = _geometricalFrameManager.AddFrame(-10,10);
            Assert.AreEqual(frameAdded, false);
        }

        /// <summary>
        /// InValid decimal point Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithValidCoordinatesDuplicateCheckReturnsFalse()
        {
            bool frameAdded = _geometricalFrameManager.AddFrame(15, -15);
            Assert.AreEqual(frameAdded, true);

            //Try to add duplicate frame returns false
            bool duplicateframeAdded = _geometricalFrameManager.AddFrame(15, -15);
            Assert.AreEqual(duplicateframeAdded, false);
        }

        /// <summary>
        /// InValid decimal point Input Frame will not be added
        /// </summary>
        [Test]
        public void AddFrameWithValidCoordinatesDecimalDuplicateCheckReturnsFalse()
        {
            bool frameAdded = _geometricalFrameManager.AddFrame(35.5, -15);
            Assert.AreEqual(frameAdded, true);

            //Try to add duplicate frame returns false
            bool duplicateframeAdded = _geometricalFrameManager.AddFrame(15.0, -15.0);
            Assert.AreEqual(duplicateframeAdded, false);
        }

        /// <summary>
        /// Valid t Input Frame will be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithValidCoordinates()
        {
            //Add Frame and test Modify
            bool frameAdded = _geometricalFrameManager.AddFrame(10, -10);
            bool frameModified = _geometricalFrameManager.ModifyFrame(10, -12);
            Assert.AreEqual(frameModified, true);
        }

        /// <summary>
        /// Valid t Input Frame will be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithValidDecimalCoordinatesReturnsTrue()
        {
            //Add Frame and test Modify
            bool frameAdded = _geometricalFrameManager.AddFrame(10, -10);
            bool frameModified = _geometricalFrameManager.ModifyFrame(50.7, -40.2);
            Assert.AreEqual(frameModified, true);
        }

        /// <summary>
        /// Invalid  Input Frame will not be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithInValid_DecimalCoordinates()
        {
            //Add Frame and test Modify
            bool frameAdded = _geometricalFrameManager.AddFrame(10, -10);
            bool frameModified = _geometricalFrameManager.ModifyFrame(0, 0);
            Assert.AreEqual(frameModified, false);
        }

        /// <summary>
        /// Invalid  Input Frame will not be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithValidDecimalCoordinates()
        {
            //Add Frame and test Modify
            bool frameAdded = _geometricalFrameManager.AddFrame(10, -10);
            bool frameModified = _geometricalFrameManager.ModifyFrame(13.5, -10);
            Assert.AreEqual(frameModified, true);
        }

        /// <summary>
        /// Invalid  Input Frame will not be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithInvalidCoordinates()
        {
            //Add Frame and test Modify
            bool frameAdded = _geometricalFrameManager.AddFrame(10, -10);
            bool frameModified = _geometricalFrameManager.ModifyFrame(-10, -10);
            Assert.AreEqual(frameModified, false);
        }

        /// <summary>
        /// Invalid  Input Frame will not be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithInValidCoordinatesReturnsFalse()
        {
            //Add Frame and test Modify
            bool frameAdded = _geometricalFrameManager.AddFrame(10, -10);
            bool frameModified = _geometricalFrameManager.ModifyFrame(.7, 0);
            Assert.AreEqual(frameModified, false);
        }

        /// <summary>
        /// Invalid  Input Frame will not be modified
        /// </summary>
        [Test]
        public void ModifyFrameWithInValidCoordinates_NegativePositive_ReturnsFalse()
        {
            //Add Frame and test Modify
            bool frameAdded = _geometricalFrameManager.AddFrame(10, -10);
            bool frameModified = _geometricalFrameManager.ModifyFrame(-10, 10);
            Assert.AreEqual(frameModified, false);
        }






    }
}