using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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

        [TestCase("1", 3, 0.5)]
        [TestCase("1", 4, 1.5)]
        [TestCase("2", 4, 2)]
        [TestCase("3", 1, 0.5)]
        public void BuyCommand_WithEnoughBudgetAndItemSelected_RemoveOneItemFromListAndReloadView(string slot, double startBudget, double endBudget)
        {
            //Arrange
            ISlotDataRepository repository = Substitute.For<ISlotDataRepository>();
            List<Slot> beforeSlots = new List<Slot>()
            {
                new Slot("Cola", 2.5, 10, 1),
                new Slot("Pepsi", 2.0, 8, 2),
                new Slot("Water", 0.5, 8, 3)
            };
            repository.LoadData().Returns(beforeSlots);
            viewModel = new ViewModel(repository);

            //quantity of cola decreased by 1 (10 to 9)
            //Note: when buying other slots than first slot with testcase
            //this afterslots list will still be returned (hard to test with testcases, multiple tests necessary)
            //with the testcases, we were interested in the changes to the budget so I leave it like this
            List<Slot> afterSlots = new List<Slot>()
            {
                new Slot("Cola", 2.5, 9, 1),
                new Slot("Pepsi", 2.0, 8, 2),
                new Slot("Water", 0.5, 8, 3)
            };
            repository.LoadData().Returns(afterSlots);

            viewModel.Budget = startBudget;
            viewModel.SelectedSlot = slot;

            //Act
            viewModel.BuyCommand.Execute(null);

            //Assert
            repository.Received(1).RemoveOneItemFromSlot(Arg.Any<int>());
            Assert.That(viewModel.Slots.ElementAt(0).Quantity, Is.EqualTo(9));
            Assert.That(viewModel.Slots, Is.EqualTo(afterSlots));
            Assert.That(viewModel.Budget, Is.EqualTo(endBudget));
            Assert.IsEmpty(viewModel.SelectedSlot);
            Assert.IsEmpty(viewModel.ErrorMessage);
        }

        [Test]
        public void BuyCommand_WithNoItemSelected_PropperErrorMessageSetAndPurchaseNotExecuted()
        {
            //Arrange
            ISlotDataRepository repository = Substitute.For<ISlotDataRepository>();
            List<Slot> beforeSlots = new List<Slot>()
            {
                new Slot("Cola", 2.5, 10, 1),
                new Slot("Pepsi", 2.0, 8, 2)
            };
            repository.LoadData().Returns(beforeSlots);
            viewModel = new ViewModel(repository);

            viewModel.Budget = 3;

            //Act
            viewModel.BuyCommand.Execute(null);

            //Assert
            repository.DidNotReceive().RemoveOneItemFromSlot(1);
            Assert.That(viewModel.Slots, Is.EqualTo(beforeSlots));
            Assert.That(viewModel.Budget, Is.EqualTo(3.0));
            Assert.That(viewModel.ErrorMessage, Is.EqualTo("Invalid slot"));
        }

        [Test]
        public void BuyCommand_WithSelectedSlotButNotANumber_PropperErrorMessageSetAndPurchaseNotExecuted()
        {
            //Arrange
            ISlotDataRepository repository = Substitute.For<ISlotDataRepository>();
            List<Slot> beforeSlots = new List<Slot>()
            {
                new Slot("Cola", 2.5, 10, 1),
                new Slot("Pepsi", 2.0, 8, 2)
            };
            repository.LoadData().Returns(beforeSlots);
            viewModel = new ViewModel(repository);

            viewModel.Budget = 3;
            viewModel.SelectedSlot = "vijf";

            //Act
            viewModel.BuyCommand.Execute(null);

            //Assert
            repository.DidNotReceive().RemoveOneItemFromSlot(1);
            Assert.That(viewModel.Slots, Is.EqualTo(beforeSlots));
            Assert.That(viewModel.Budget, Is.EqualTo(3.0));
            Assert.That(viewModel.ErrorMessage, Is.EqualTo("Invalid slot"));
        }

        [Test]
        public void BuyCommand_WithSelectedSlotButOutOfBounds_PropperErrorMessageSetAndPurchaseNotExecuted()
        {
            //Arrange
            ISlotDataRepository repository = Substitute.For<ISlotDataRepository>();
            List<Slot> beforeSlots = new List<Slot>()
            {
                new Slot("Cola", 2.5, 10, 1),
                new Slot("Pepsi", 2.0, 8, 2)
            };
            repository.LoadData().Returns(beforeSlots);
            viewModel = new ViewModel(repository);

            viewModel.Budget = 3;
            viewModel.SelectedSlot = "5";

            //Act
            viewModel.BuyCommand.Execute(null);

            //Assert
            repository.DidNotReceive().RemoveOneItemFromSlot(1);
            Assert.That(viewModel.Slots, Is.EqualTo(beforeSlots));
            Assert.That(viewModel.Budget, Is.EqualTo(3.0));
            Assert.That(viewModel.ErrorMessage, Is.EqualTo("Invalid slot"));
        }

        [Test]
        public void BuyCommand_WithNotEnoughBudget_PropperErrorMessageSetAndPurchaseNotExecuted()
        {
            //Arrange
            ISlotDataRepository repository = Substitute.For<ISlotDataRepository>();
            List<Slot> beforeSlots = new List<Slot>()
            {
                new Slot("Cola", 2.5, 10, 1),
                new Slot("Pepsi", 2.0, 8, 2)
            };
            repository.LoadData().Returns(beforeSlots);
            viewModel = new ViewModel(repository);

            viewModel.Budget = 1;
            viewModel.SelectedSlot = "1";

            //Act
            viewModel.BuyCommand.Execute(null);

            //Assert
            repository.DidNotReceive().RemoveOneItemFromSlot(1);
            Assert.That(viewModel.Slots, Is.EqualTo(beforeSlots));
            Assert.That(viewModel.Budget, Is.EqualTo(1.0));
            Assert.That(viewModel.ErrorMessage, Is.EqualTo("Insufficient funds"));
        }
    }
}