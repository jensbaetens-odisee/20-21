using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PersonAgeValidator.Tests._1
{
    //extra nuget packages
    // NSubstitute
    // NSubstitute.Analyzers.CSharp

    [TestFixture]
    class PersonTestsWithNSubstitute
    {
        [Test]
        public void Ctor_WithValidAge_ReturnsUser()
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

        [Test]
        public void Ctor_WithInValidAge_ThrowsError()
        {
            //Arrange
            string firstname = "John";
            string lastname = "Doe";
            //age only necessary for using in the constructor
            int age = 0;
            IAgeValidator stub = Substitute.For<IAgeValidator>();
            stub.IsValidAge(age).Returns(false);

            //Act is de new person in de assert

            //Assert
            Assert.Throws<Exception>(() => new Person(firstname, lastname, age));
        }
    }
}
