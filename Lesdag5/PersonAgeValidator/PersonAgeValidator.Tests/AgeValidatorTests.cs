using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator.Tests._1
{
    [TestFixture]
    class AgeValidatorTests
    {
        //Age valid
        [TestCase(18)]
        [TestCase(70)]
        [TestCase(36)]
        public void IsValidAge_ValidAges_ReturnTrue(int age)
        {
            //Arrange
            AgeValidator ageValidator = new AgeValidator();

            //Act
            bool result = ageValidator.IsValidAge(age);

            //Assert
            Assert.IsTrue(result);
        }

        //Age not valid
        [TestCase(17)]
        [TestCase(71)]
        [TestCase(10)]
        [TestCase(80)]
        public void IsValidAge_InvalidAges_ReturnFalse(int age)
        {
            //Arrange
            AgeValidator ageValidator = new AgeValidator();

            //Act
            bool result = ageValidator.IsValidAge(age);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
