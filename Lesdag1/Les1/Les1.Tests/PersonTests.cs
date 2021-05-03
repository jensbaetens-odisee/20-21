using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Les1.Tests
{
    [TestFixture]
    class PersonTests
    {
        [TestCase(18, ExpectedResult =true)]
        [TestCase(20, ExpectedResult = true)]
        [TestCase(100, ExpectedResult = true)]
        [TestCase(8, ExpectedResult = false)]
        [TestCase(17, ExpectedResult = false)]
        public bool CanVote_PersonIsAtLeast18_AllowedToVote(int age)
        {
            //Arrange
            Person person = new Person();
            person.Age = age;

            //Act
            bool result = person.CanVote();

            //Assert
            return result;
            //Assert.That(result, Is.EqualTo(true));
        }
    }
}
