using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GradesHelper.Tests.NSubstitute
{
    [TestFixture]
    class GradeRepositoryTests
    {
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

        [Test]
        public void GetGrades_ReturnAllGrades() { 

            //Arrange
            var dbContext = Substitute.For<StudentsDbContext>();
            var studentdbSet = Substitute.For<DbSet<Student>, IQueryable<Student>>();
            ((IQueryable<Student>)studentdbSet).Provider.Returns(students.AsQueryable().Provider);
            ((IQueryable<Student>)studentdbSet).Expression.Returns(students.AsQueryable().Expression);
            ((IQueryable<Student>)studentdbSet).GetEnumerator().Returns(students.AsQueryable().GetEnumerator());
            //Of met de functie
            studentdbSet = GenerateMockDbSet<Student>(students);

            dbContext.Students.Returns(studentdbSet);

            GradeRepository sut = new GradeRepository(dbContext);

            //Act
            List<int> grades = sut.GetGrades(students[0]);

            //Assert
            Assert.AreEqual(grades, new List<int>() { 1, 2, 3, 4, 5 });

        }

        //functie waar T een willekeurige klasse is (hier bijvoorbeeld student)
        //dit gaat eigenlijk de Substitute voor de DbSet gaan aanmaken.
        public static DbSet<T> GenerateMockDbSet<T>(List<T> data) where T: class
        {
            var dbSet = Substitute.For<DbSet<T>, IQueryable<T>>();

            ((IQueryable<T>)dbSet).Provider.Returns(data.AsQueryable().Provider);
            ((IQueryable<T>)dbSet).Expression.Returns(data.AsQueryable().Expression);
            ((IQueryable<T>)dbSet).GetEnumerator().Returns(data.AsQueryable().GetEnumerator());
            ((IQueryable<T>)dbSet).ElementType.Returns(data.AsQueryable().ElementType);

            return dbSet;
        }
    }
}
