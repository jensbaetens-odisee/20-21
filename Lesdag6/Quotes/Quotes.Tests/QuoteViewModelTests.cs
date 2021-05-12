using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotes.Tests
{
    [TestFixture]
    class QuoteViewModelTests
    {
        QuoteViewModel sut;

        ICoordinator coordinator;

        [SetUp]
        public void Initialize()
        {
            //Arrange
            coordinator = Substitute.For<ICoordinator>();
            ICloseable closeable = Substitute.For<ICloseable>();
            IQuoteRepository repository = Substitute.For<IQuoteRepository>();
            sut = new QuoteViewModel(coordinator, closeable, repository);
        }

        [Test]
        public void SelectedQuote_ItemSelected_AuthorAndTextPropertiesAreChanged()
        {
            //Arrange
            Quote quote = new Quote("text", "author");

            //Act
            sut.SelectedQuote = quote;

            //Assert
            Assert.AreEqual(sut.Text, quote.Text);
            Assert.AreEqual(sut.Author, quote.Author);

            coordinator.DidNotReceive().ShowDialog(Arg.Any<string>());
        }

        [Test]
        public void Text_Changed_PropertyChangedEventIsFired()
        {
            string property = "";
            sut.PropertyChanged += (sender, eventargs) => {
                property = eventargs.PropertyName;
            }; 

            //Act
            sut.Text = "test";

            //Assert
            Assert.AreEqual(property, "Text");
        }


        [Test]
        public void Author_Changed_PropertyChangedEventIsFired()
        {
            //Arrange
            string property = "";
            sut.PropertyChanged += (sender, eventargs) => {
                property = eventargs.PropertyName;
            };

            //Act
            sut.Author = "test";

            //Assert
            Assert.AreEqual(property, "Author");
        }

        [Test]
        public void CreateCommand_WithAuthorAndTextFilled_AddNewItemToQuotes()
        {
            //Arrange
            sut.Author = "A";
            sut.Text = "T";

            //Act
            sut.CreateQuoteCommand.Execute(null);

            //Assert
            Assert.AreEqual(sut.Quotes.Count, 1);
            Assert.AreEqual(sut.Quotes[0].Text, "T");
            Assert.AreEqual(sut.Quotes[0].Author, "A");
            //This is also possible but need to override Equals()
            //Assert.AreEqual(sut.Quotes[0], new Quote("T", "A"));
            
        }
    }
}
