using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Exercises;
using System.Linq;

namespace ExercisesTests
{
    [TestFixture]
    class NumberOperationsTests
    {
        [Test]
        public void GetAllNumbersLargerOrEqualTo50_HappyFlow_ReturnsCorrectNumbers()
        {
            //Arrange
            int[] array = { 1, 200, 3 };
            NumbersOperations operations = new NumbersOperations(array);

            //Act
            IEnumerable<int> result = operations.GetAllNumbersLargerOrEqualTo50();

            //Assert
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.Last, Is.EqualTo(50));
            Assert.That(result.First, Is.EqualTo(200));
            Assert.That(result.ElementAt(0), Is.EqualTo(200));
            Assert.That(result.ElementAt(1), Is.EqualTo(300));
            Assert.That(result.ElementAt(2), Is.EqualTo(50));
        }

        [Test]
        public void GetLastNumberWithSquareLessThan2000()
        {
            //Arrange
            int[] array = { 1, 200, 3, 300, 4, 500, 50 };
            NumbersOperations operations = new NumbersOperations(array);

            //Act
            int result = operations.GetLastNumberWithSquareLessThan2000();

            //Assert
            Assert.That(result, Is.EqualTo(4));
        }
    }
}
