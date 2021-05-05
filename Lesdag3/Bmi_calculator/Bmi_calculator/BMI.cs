using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmi_calculator
{
    class BMI
    {
        public double Weight { get; set; }
        public double Height { get; set; }

        [Column(TypeName ="date")]
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public double Bmi { get; set; }

    }
}
