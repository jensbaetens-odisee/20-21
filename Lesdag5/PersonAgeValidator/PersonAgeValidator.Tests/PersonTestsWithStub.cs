using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PersonAgeValidator.Tests._1
{
    [TestFixture]
    class PersonTestsWithStub
    {
        // Test person created (valid age)
        [Test]
        public void Ctor_ValidAge_PersonCreated()
        {
 //Arrange
            string firstname = "John";
            string lastname = "Doe";
            //age only necessary for using in the constructor
            int age = 0;
            IAgeValidator stub = Substitute.For<IAgeValidator>();
            //stub.IsValidAge(age).Returns(true);
            stub.IsValidAge(Arg.Any<int>()).Returns(true);

            //Act
            Person person = new Person(firstname, lastname, age, stub);

            //Assert
            Assert.That(person.FirstName, Is.EqualTo(firstname));
            Assert.That(person.LastName, Is.EqualTo(lastname));
            Assert.That(person.Age, Is.EqualTo(age));
        }

        // Test person not created (invalid age/ exception throwed)
        [Test]
        public void Ctor_InvalidAge_ThrowsException()
        {
            //Arrange
            string firstname = "John";
            string lastname = "Doe";
            //age only necessary for using in the constructor
            int age = 0;
            AgeValidatorStub stub = new AgeValidatorStub(false);

            //Act is de new person in de assert

            //Assert
            Assert.Throws<Exception>(() => new Person(firstname, lastname, age));
        }
    }
}
