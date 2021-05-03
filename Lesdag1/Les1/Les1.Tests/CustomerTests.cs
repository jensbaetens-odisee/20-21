using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Les1.Tests
{
    [TestFixture]
    class CustomerTests
    {
        private Store store;
        private Customer sut;

        [SetUp]
        public void Initialize()
        {
            store = new Store();
            store.AddInventory(Product.Shampoo, 10);
            sut = new Customer();
        }

        [Test]
        public void Purchase_WithEnoughInventory_ReturnsTrueStockChanged()
        {
            //Arrange

            //Act
            bool result = sut.Purchase(store, Product.Shampoo, 2);

            //Assert
            Assert.IsTrue(result);
            Assert.That(sut.Basket[Product.Shampoo], Is.EqualTo(2));
            Assert.That(store.GetInventory(Product.Shampoo), Is.EqualTo(8));
        }

        [Test]
        public void Purchase_WithoutEnoughInventory_ReturnsFalse()
        {
            //Arrange

            //Act
            bool result = sut.Purchase(store, Product.Shampoo, 20);

            //Assert
            Assert.IsFalse(result);
            Assert.That(store.GetInventory(Product.Shampoo), Is.EqualTo(10));
        }
    }
}
