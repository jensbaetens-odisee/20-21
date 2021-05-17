using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTDD.Tests
{
    [TestFixture]
    class SlotTests
    {
        [Test]
        public void Ctor_WithValidData_AllPropertiesFilled()
        {
            //Arrange
            string name = "Cola";
            double price = 2.5;
            int quantity = 10;
            int slotNumber = 1;

            //Act
            Slot sut = new Slot(name, price, quantity, slotNumber);

            //Assert
            Assert.That(sut.Name, Is.EqualTo(name));
            Assert.That(sut.Price, Is.EqualTo(price));
            Assert.That(sut.Quantity, Is.EqualTo(quantity));
            Assert.That(sut.SlotNumber, Is.EqualTo(slotNumber));
        }
    }
}
