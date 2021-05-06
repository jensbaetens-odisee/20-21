using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GradesHelper
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<int> Scores { get; set; }
    }
}