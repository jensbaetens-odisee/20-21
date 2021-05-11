using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry
{
    public class Bezoeker
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Voornaam {get;set;}
        public string LastName { get; set; }
        public List<Contact> Contacten { get; set; }
    }
}
