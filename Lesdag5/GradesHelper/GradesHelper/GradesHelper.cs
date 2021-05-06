using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelper
{
    public class GradesHelper
    {
        private readonly IGradeRepository gradeRepository;

        public GradesHelper(IGradeRepository gradeRepository)
        {
            this.gradeRepository = gradeRepository;
        }

        public GradesHelper()
        {
            this.gradeRepository = new GradeRepository();
        }

        public double CalcAverageGrade(Student student)
        {
            List<int> grades = gradeRepository.GetGrades(student);

            double totalScore = 0;

            foreach (var grade in grades)
            {
                totalScore += grade;
            }

            return totalScore / grades.Count;
        }
        public bool DidStudentPerformBetterWithNewScore(Student s, int score)
        {
            double oldAvgScore = CalcAverageGrade(s);

            gradeRepository.AddScore(s, score);

            double newAvgScore = CalcAverageGrade(s);

            return newAvgScore > oldAvgScore;
        }

        public void RemoveAllScores(Student student)
        {
            gradeRepository.ClearScore(student);
        }

        public void AddScore(Student student, int score)
        {
            if (score < 0)
            {
                throw new Exception();
            }

            gradeRepository.AddScore(student, score);
        }
    }
}
