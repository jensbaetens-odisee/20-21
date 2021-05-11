using NUnit.Framework;
using System;

namespace GradesHelper.Tests
{
    [TestFixture]
    public class GradesHelperTests
    {
        [Test]
        public void CalcAverageGrade_SomeNumbersEntered_ReturnsAverage()
        {
            //Arrange
            //Stub: fixed hard coded values that cannot be changed
            IGradeRepository stub = new GradeRepositoryStub();
            GradesHelper sut = new GradesHelper(stub);
            //Student s can be zero because s.GetGrades() or s.Scores is not done (stubbed)
            Student s = null;

            //Act
            double average = sut.CalcAverageGrade(s);

            //Assert
            Assert.AreEqual(average, 5);
        }

        [Test]
        public void DidStudentPerformBetterWithNewScore_WithBadScore_ReturnsFalse()
        {
            //Arrange
            //The function DidStudentPerformBetterWithNewScore voegt iets toe aan de score lijst
            //Dit vereist extra logica om de state bij te houden en aan te passen (AddScore)
            //Dit wordt fake genoemd
            IGradeRepository fake = new GradeRepositoryFake();
            GradesHelper sut = new GradesHelper(fake);
            Student s = null;

            //Act
            bool result = sut.DidStudentPerformBetterWithNewScore(s, 0);

            //Assert
            Assert.IsFalse(result);
        }


        [Test]
        public void DidStudentPerformBetterWithNewScore_WithBadScore_ReturnsTrue()
        {
            //Arrange
            IGradeRepository fake = new GradeRepositoryFake();
            GradesHelper sut = new GradesHelper(fake);
            Student s = null;

            //Act
            bool result = sut.DidStudentPerformBetterWithNewScore(s, 10);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveAllScores_ClearScoreIsCalled()
        {
            //Arrange
            IGradeRepository mock = new GradeRepositoryMock();
            GradesHelper sut = new GradesHelper(mock);
            Student s = null;

            //Act
            sut.RemoveAllScores(s);

            //Assert
            Assert.Fail();
        }

        [Test]
        public void AddScore_WithValidData_AddScoreIsCalled()
        {
            //Arrange
            //Spy must be GradeRepositorySpy, otherwise we cannot do spy.AddScoreIsCalled
            GradeRepositorySpy spy = new GradeRepositorySpy();
            GradesHelper sut = new GradesHelper(spy);
            Student s = null;

            //Act
            sut.AddScore(s, 5);

            //Assert
            Assert.IsTrue(spy.AddScoreIsCalled);
            Assert.That(spy.LatestAddedScoreIs, Is.EqualTo(5));
        }

        [Test]
        public void AddScore_WithInvalidData_AddScoreNotCalled()
        {
            //Arrange
            //Spy must be GradeRepositorySpy, otherwise we cannot do spy.AddScoreIsCalled
            GradeRepositorySpy spy = new GradeRepositorySpy();
            GradesHelper sut = new GradesHelper(spy);
            Student s = null;

            //Act
            Assert.Throws<Exception>( () =>
                { sut.AddScore(s, -5); }
            );

            //Assert
            Assert.IsFalse(spy.AddScoreIsCalled);
        }
    }
}
