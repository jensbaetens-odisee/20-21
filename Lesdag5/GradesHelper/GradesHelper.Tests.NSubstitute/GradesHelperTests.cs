using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GradesHelper.Tests.NSubstitute
{
    [TestFixture]
    public class GradesHelperTests
    {

        [Test]
        public void CalcAverageGrade_SomeNumbersEntered_ReturnsAverage()
        {
            // Arrange
            IGradeRepository gradeRepository = Substitute.For<IGradeRepository>();
            GradesHelper sut = new GradesHelper(gradeRepository);
            Student student1 = new Student();
            Student student2 = new Student();
            List<int> grades1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> grades2 = new List<int>() { 8, 8, 8, 8, 8 };
            gradeRepository.GetGrades(default).ReturnsForAnyArgs(grades1, grades2);

            // Act
            double averageScore1 = sut.CalcAverageGrade(student1);
            double averageScore2 = sut.CalcAverageGrade(student2);

            // Assert
            Assert.AreEqual(5, averageScore1);
            Assert.AreEqual(8, averageScore2);
        }

        [Test]
        public void DidStudentPerformBetterWithNewScore_WithBadScore_ReturnsFalse()
        {
            // Arrange
            IGradeRepository gradeRepository = Substitute.For<IGradeRepository>();
            GradesHelper sut = new GradesHelper(gradeRepository);
            Student s = null;
            int score = 3;
            List<int> scores = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            gradeRepository.When(x => x.AddScore(s, score)).Do(x => scores.Add(x.ArgAt<int>(1)));
            gradeRepository.GetGrades(s).Returns(x => scores);

            // Act
            bool result = sut.DidStudentPerformBetterWithNewScore(s, score);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DidStudentPerformBetterWithNewScore_WithGoodScore_ReturnsFalse()
        {
            // Arrange
            IGradeRepository gradeRepository = Substitute.For<IGradeRepository>();
            Student s = null;
            List<int> scores = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int score = 7;
            gradeRepository.When(x => x.AddScore(s, Arg.Any<int>())).Do(x => scores.Add(x.ArgAt<int>(1)));
            gradeRepository.GetGrades(s).Returns(x => scores);
            GradesHelper sut = new GradesHelper(gradeRepository);


            // Act
            bool result = sut.DidStudentPerformBetterWithNewScore(s, score);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveAllScores__RemoveAllScoresIsCalled()
        {
            // Arrange
            IGradeRepository gradeRepository = Substitute.For<IGradeRepository>();
            GradesHelper sut = new GradesHelper(gradeRepository);
            Student s = null;
            gradeRepository.When(x => x.ClearScore(s)).Do(x => Assert.Pass());

            // Act
            sut.RemoveAllScores(s);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void RemoveAllScores__RemoveAllScoresIsCalled2()
        {
            // Arrange
            IGradeRepository gradeRepository = Substitute.For<IGradeRepository>();
            GradesHelper sut = new GradesHelper(gradeRepository);
            Student s = null;

            // Act
            sut.RemoveAllScores(s);

            // Assert
            gradeRepository.Received(1).ClearScore(default);
            gradeRepository.Received(1).ClearScore(Arg.Any<Student>());
        }


        [Test]
        public void AddScore_WithValidData_AddScoreIsCalled()
        {
            // Arrange
            IGradeRepository gradeRepository = Substitute.For<IGradeRepository>();
            GradesHelper sut = new GradesHelper(gradeRepository);
            Student s = null;
            int score = 5;

            // Act
            sut.AddScore(s, score);

            // Assert
            gradeRepository.Received().AddScore(s, score);
        }

        [Test]
        public void AddScore_WithInValidData_ExceptionIsThrownAddScoreNotCalled()
        {
            // Arrange
            IGradeRepository gradeRepository = Substitute.For<IGradeRepository>();
            GradesHelper sut = new GradesHelper(gradeRepository);
            Student s = null;
            int score = -1;

            // Act
            Assert.Throws<Exception>(() =>
            {
                sut.AddScore(s, score);
            });

            // Assert
            gradeRepository.DidNotReceive().AddScore(s, score);
        }
    }
}
