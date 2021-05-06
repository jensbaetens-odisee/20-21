using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHelper
{
    public class StudentsDbContext: DbContext
    {
        public StudentsDbContext():base("students")
        {

        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
