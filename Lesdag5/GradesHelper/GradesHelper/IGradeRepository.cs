using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelper
{
    public interface IGradeRepository
    {
        List<int> GetGrades(Student student);
        void AddScore(Student student, int score);
        int GetTotalScore(Student student);
        void ClearScore(Student student);
    }
}
