using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace DemoTDD.Tests
{
    public class Tests
    {
        ViewModel viewModel;

        [SetUp]
        public void Setup()
        {

            viewModel = new ViewModel(null);
        }

        [Test]
        public void Add1EuroCommand_Adds1EuroToBudget()
        {
            //Arrange

            //Act
            viewModel.Add1EuroCommand.Execute(null);

            //Assert
            Assert.AreEqual(viewModel.Budget, 1.0);
        }

        [Test]
        public void Add2EuroCommand_Adds2EuroToBudget()
        {
            //Arrange

            //Act
            viewModel.Add2EuroCommand.Execute(null);

            //Assert
            Assert.AreEqual(viewModel.Budget, 2.0);
        }

        //Test andere munten zelf

        [Test]
        public void Add1EuroCommand_With1EuroInBudget_BugetIs2Euros()
        {
            //Arrange
            viewModel.Budget = 1.0;

            //Act
            viewModel.Add1EuroCommand.Execute(null);

            //Assert
            Assert.That(viewModel.Budget, Is.EqualTo( 2.0));
        }

        [Test]
        public void Add2EuroCommand_With1EuroInBudget_BugetIs3Euros()
        {
            //Arrange
            viewModel.Budget = 1.0;

            //Act
            viewModel.Add2EuroCommand.Execute(null);

            //Assert
            Assert.That(viewModel.Budget, Is.EqualTo(3.0));
        }

        [Test]
        public void Budget_Changed_OnPropertyChangedIsCalled()
        {
            //Arrange
            string changedProperty = "";
            viewModel.PropertyChanged += (e, args) =>
            {
                changedProperty = args.PropertyName;
            };

            //Act
            viewModel.Budget = 5;

            //Assert
            Assert.That(changedProperty, Is.EqualTo("Budget"));
        }

        [Test]
        public void RefundCommand_WithBudget_BudgetBecomesZero()
        {
            //Arrange
            viewModel.Budget = 2;

            //Act
            viewModel.RefundCommand.Execute(null);

            //Assert
            Assert.That(viewModel.Budget, Is.EqualTo(0.0));
        }

        [Test]
        public void Ctor_WithNoItems_CreatesEmptySlotList()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(viewModel.Slots.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_WithDataFromDatabase_AddDataToList()
        {
            //Arrange
            ISlotDataRepository repository = Substitute.For<ISlotDataRepository>();
            List<Slot> slots = new List<Slot>()
            {
                new Slot("Cola", 2.5, 10, 1),
                new Slot("Pepsi", 2.0, 8, 2)
            };
            repository.LoadData().Returns(slots);
            //GetAllSlots()

            //Act
            viewModel = new ViewModel(repository);

            //Assert
            Assert.That(viewModel.Slots.Count, Is.EqualTo(2));
            Assert.That(viewModel.Slots, Is.EqualTo(slots));
        }

        [Test]
        public void BuyCommand_WithEnoughBudgetAndItemSelected_RemoveOneItemFromListAndReloadView()
        {

        }
    }
}