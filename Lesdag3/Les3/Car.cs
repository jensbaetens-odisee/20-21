using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Les3
{
    class Car
    {
        public Car()
        {
            Users = new List<User>();

        }

        //brand is required, model niet
        public Car(string merk)
        {
            Brand = merk;
            Users = new List<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Merk")]
        [StringLength(200)]
        public string Brand { get; set; }

        //Tags niet nodig omdat we het doen in de OnModelCreating functie
        //[Required]
        //[Column("Reeks")]  // wijzigt kolomnaam in database
        //[StringLength(200)]
        //[NotMapped] -- wordt niet opgeslaan
        public string Model { get; set; }
        
        public List<User> Users { get; set; }
    }
}
