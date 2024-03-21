using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SHAA3209;

namespace SHAA3209.Tests
{
    [TestClass]
    public class UnitTestForCalculator
    {
        [TestMethod]
        public void TestMethodForSum()
        {
            //Arrange
            double[] array1 = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expectedsum1 = 25.60;

            //Act
            double sumresult1 = ArrayCalculator.Sum(array1);

            //Assert
            Assert.AreEqual(expectedsum1, sumresult1);
        }
        [TestMethod]
        public void TestMethodForAverage()
        {
            //Arrange
            double[] array1 = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expectedavg1 = 3.66;

            //Act
            double avgresult1 = ArrayCalculator.Average(array1);

            //Assert
            Assert.AreEqual(expectedavg1, avgresult1);
        }
        [TestMethod]
        public void TestMethodForMin()
        {
            //Arrange
            double[] array1 = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expectedmin1 = -4.5;

            //Act
            double minresult1 = ArrayCalculator.Min(array1);

            //Assert
            Assert.AreEqual(expectedmin1, minresult1);
        }
        [TestMethod]
        public void TestMethodForMax()
        {
            //Arrange
            double[] array1 = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expectedmax1 = 12;

            //Act
            double maxresult1 = ArrayCalculator.Max(array1);

            //Assert
            Assert.AreEqual(expectedmax1, maxresult1);
        }
        [TestMethod]
        public void TestMethodForSumEmpty()
        {
            //Arrange
            double[] array2 = { };
            double expectedsum2 = 0;

            //Act
            double sumresult2 = ArrayCalculator.Sum(array2);

            //Assert
            Assert.AreEqual(expectedsum2, sumresult2);
        }
        [TestMethod]
        public void TestMethodForAverageEmpty()
        {
            //Arrange
            double[] array2 = { };
            double expectedavg2 = 0;

            //Act
            double avgresult2 = ArrayCalculator.Average(array2);

            //Assert
            Assert.AreEqual(expectedavg2, avgresult2);
        }
        [TestMethod]
        public void TestMethodForMinEmpty()
        {
            //Arrange
            double[] array2 = { };
            double expectedmin2 = 0;

            //Act
            double minresult2 = ArrayCalculator.Min(array2);

            //Assert
            Assert.AreEqual(expectedmin2, minresult2);
        }
        [TestMethod]
        public void TestMethodForMaxEmpty()
        {
            //Arrange
            double[] array2 = { };
            double expectedmax2 = 0;

            //Act
            double maxresult2 = ArrayCalculator.Max(array2);

            //Assert
            Assert.AreEqual(expectedmax2, maxresult2);
        }
    }
}
