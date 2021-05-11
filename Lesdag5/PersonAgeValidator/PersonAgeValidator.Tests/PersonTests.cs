using NUnit.Framework;
using System;

namespace PersonAgeValidator.Tests._1
{
    [TestFixture]
    public class PersonTests
    {
        // Test person created (valid age)
        [TestCase(18)]
        [TestCase(70)]
        [TestCase(36)]
        public void Ctor_ValidAges_PersonCreated(int age)
        {
            //Arrange
            string firstname = "John";
            string lastname = "Doe";

            //Act
            Person person = new Person(firstname, lastname, age);

            //Assert
            Assert.That(person.FirstName, Is.EqualTo(firstname));
            Assert.That(person.LastName, Is.EqualTo(lastname));
            Assert.That(person.Age, Is.EqualTo(age));
        }

        // Test person not created (invalid age/ exception throwed)
        [TestCase(17)]
        [TestCase(71)]
        [TestCase(10)]
        [TestCase(80)]
        public void Ctor_InvalidAges_ThrowsException(int age)
        {
            //Arrange
            string firstname = "John";
            string lastname = "Doe";

            //Act is de new person in de assert

            //Assert
            Assert.Throws<Exception>(() => new Person(firstname, lastname, age));
        }
    }
}
