using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmi_calculator
{
    class BMIRepository
    {
        private DatabaseContext context = new DatabaseContext();

        public void AddBMI(BMI bmi)
        {
            context.BMIs.Add(bmi);
            context.SaveChanges();
        }

        public List<BMI> GetBMIs()
        {
            return context.BMIs.ToList();
        }

        public void UpdateBMI(BMI user)
        {
            context.SaveChanges();
        }

        public void DeleteBMI(BMI bmi)
        {
            context.BMIs.Remove(bmi);
            context.SaveChanges();
        }
    }
}
