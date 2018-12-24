using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandboxLibrary.Yield;
using System.Collections.Generic;

namespace SandboxLibraryTest.Yield
{
    [TestClass]
    public class YieldExampleTests
    {
        [TestInitialize]
        public void TestSetup()
        {
        }

        [TestMethod]
        public void FilterWithoutYieldTest()
        {
            // Arrange
            var classToTest = new YieldExample<int>
            {
                MyEnumerable = new int[] { 1, 2, 3, 4, 5, 6 }
            };
            var expectedResult = new int[] { 4, 5, 6 };

            // Act
            var actualResult = classToTest.FilterWithoutYield(x => x > 3);

            // Assert
            //This is the comparison class
            var compareLogic = new CompareLogic();
            var result = compareLogic.Compare(expectedResult, actualResult);

            Assert.IsTrue(result.AreEqual);
        }

        [TestMethod]
        public void FilterWithYieldTest()
        {
            // Arrange
            var classToTest = new YieldExample<int>
            {
                MyEnumerable = new int[] { 1, 2, 3, 4, 5, 6 }
            };
            var expectedResult = new int[] { 4, 5, 6 };

            // Act
            var actualResult = new List<int>();
            foreach (var item in classToTest.FilterWithYield(x => x > 3))
            {
                actualResult.Add(item);
            }

            // Assert
            //This is the comparison class
            var compareLogic = new CompareLogic();
            var result = compareLogic.Compare(expectedResult, actualResult.ToArray());

            Assert.IsTrue(result.AreEqual);
        }

        [TestMethod]
        public void SummariseWithYield()
        {
            // Arrange
            var classToTest = new YieldExample<int>
            {
                MyEnumerable = new int[] { 1, 2, 3, 4, 5, 6 }
            };


            // Act
            var actualResult = new List<int>();
            foreach (var item in classToTest.SummariseWithYield((x,y) => x + y))
            {
                actualResult.Add(item);
            }

            // Assert
            //This is the comparison class
            var compareLogic = new CompareLogic();
            var result = compareLogic.Compare(new List<int> { 1, 3, 6, 10, 15, 21 }, actualResult);

            Assert.IsTrue(result.AreEqual);
        }
    }
}
