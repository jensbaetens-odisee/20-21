using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmi_calculator
{
    class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Column("Naam")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName ="date")]
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
