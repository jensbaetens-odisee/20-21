using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GradesHelper.Tests.NSubstitute
{
    [TestFixture]
    class GradeRepositoryTests
    {


        [Test]
        public void GetGrades__ReturnsAllGrades1()
        {
            // Arrange

            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id  =1,
                    FirstName = "John",
                    LastName = "Doe",
                    Scores = new List<int>(){1,2,3,4,5}
                },new Student()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Scores = new List<int>(){5,6,7,8,9}
                }
            };
            var dbContext = Substitute.For<StudentsDbContext>();
            var studentDbSet = Substitute.For<DbSet<Student>, IQueryable<Student>>();
            ((IQueryable<Student>)studentDbSet).Provider.Returns(students.AsQueryable().Provider);
            ((IQueryable<Student>)studentDbSet).Expression.Returns(students.AsQueryable().Expression);
            ((IQueryable<Student>)studentDbSet).GetEnumerator().Returns(students.GetEnumerator()); 
            dbContext.Students.Returns(studentDbSet);
            GradeRepository sut = new GradeRepository(dbContext);
            Student student = new Student
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            };

            // Act
            List<int> grades = sut.GetGrades(student);

            // Assert 
            Assert.AreEqual(new List<int>() { 1, 2, 3, 4, 5 }, grades);
        }

        [Test]
        public void GetGrades__ReturnsAllGrades2()
        {
            // Arrange

            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id  =1,
                    FirstName = "John",
                    LastName = "Doe",
                    Scores = new List<int>(){1,2,3,4,5}
                },new Student()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Scores = new List<int>(){5,6,7,8,9}
                }
            };
            var dbContext = Substitute.For<StudentsDbContext>();
            var studentDbSet = NSubstituteUtils.GenerateMockDbSet<Student>(students);
            dbContext.Students.Returns(studentDbSet);
            GradeRepository sut = new GradeRepository(dbContext);
            Student student = new Student
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            };

            // Act
            List<int> grades = sut.GetGrades(student);

            // Assert 
            Assert.AreEqual(new List<int>() { 1, 2, 3, 4, 5 }, grades);
        }
    }
}
