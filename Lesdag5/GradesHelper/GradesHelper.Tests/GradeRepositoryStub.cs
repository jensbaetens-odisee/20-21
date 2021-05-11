using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelper.Tests
{
    class GradeRepositoryStub : IGradeRepository
    {
        private List<int> scores = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public void AddScore(Student student, int score)
        {
            throw new NotImplementedException();
        }

        public void ClearScore(Student student)
        {
            throw new NotImplementedException();
        }

        public List<int> GetGrades(Student student)
        {
            return scores;
        }

        public int GetTotalScore(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
