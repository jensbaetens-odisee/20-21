using NUnit.Framework;
using System;

namespace CurrencyConverter.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Arrange
            double expectedValue = 0.499999999999;

            //Act
            double result = 0.500000000001;

            //Assert
            Assert.AreEqual(result, expectedValue, 0.01);
        }
    }
}