using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GradesHelper.Tests
{
    class GradeRepositoryMock : IGradeRepository
    {
        public void AddScore(Student student, int score)
        {
            throw new NotImplementedException();
        }

        public void ClearScore(Student student)
        {
            //als we hier komen is het goed, test stopt hier
            Assert.Pass();
        }

        public List<int> GetGrades(Student student)
        {
            throw new NotImplementedException();
        }

        public int GetTotalScore(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
