using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Les2.Tests
{
    [TestFixture]
    class NumbersTests1
    {
        private Numbers numbers;

        [SetUp]
        public void Initialize()
        {
        }

        [Test]
        public void SomVanVeelvoudenVanDrie_ListEmpty_ReturnZero()
        {
            //Arrange
            numbers = new Numbers(new List<int>() { });

            //Act
            int som = numbers.SomVanVeelvoudenVanDrie();

            //Assert
            Assert.That(som, Is.EqualTo(0));
        }

        [Test]
        public void SomVanVeelvoudenVanDrie_ListZonderVeelvoudenVanDrie_ReturnZero()
        {
            //Arrange
            numbers = new Numbers(new List<int>() {2, 5 });

            //Act
            int som = numbers.SomVanVeelvoudenVanDrie();

            //Assert
            Assert.That(som, Is.EqualTo(0));
        }

        [Test]
        public void SomVanVeelvoudenVanDrie_ListMetVeelvoudenVanDrie_Return12()
        {
            //Arrange
            numbers = new Numbers(new List<int>() {3,9, 10, 14 });

            //Act
            int som = numbers.SomVanVeelvoudenVanDrie();

            //Assert
            Assert.That(som, Is.EqualTo(12));
        }
    }
}
