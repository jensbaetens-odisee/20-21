using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Les1.Tests
{
    [TestFixture]
    class CalculatorTests
    {
        [Test]
        public void Sum_TwoPositiveNumbers_ResultIsPostive()
        {
            //Arrange , Given
            int number1 = 10;
            int number2 = 20;
            Calculator sut = new Calculator();

            //Act, Then
            int result = sut.Sum(number1, number2);

            //Assert, When
            Assert.AreEqual(30, result);
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void Minus_FirstNumberLargerThanSecond_ResultIsPostive()
        {
            //Arrange , Given
            int number1 = 20;
            int number2 = 10;
            Calculator sut = new Calculator();

            //Act, Then
            int result = sut.Minus(number1, number2);

            //Assert, When
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void FlooredMinus_FirstNumberLargerThanSecond_ResultIsPostive()
        {
            //Arrange , Given
            int number1 = 20;
            int number2 = 10;
            Calculator sut = new Calculator();

            //Act, Then
            int result = sut.Minus(number1, number2);

            //Assert, When
            Assert.AreEqual(10, result);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void FlooredMinus_FirstNumberSmallerThanSecond_ResultIsPostive()
        {
            //Arrange , Given
            int number1 = 10;
            int number2 = 20;
            Calculator sut = new Calculator();

            //Act, Then
            int result = sut.FlooredMinus(number1, number2);

            //Assert, When
            Assert.AreEqual(0, result);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
