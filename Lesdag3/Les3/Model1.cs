using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Les3
{
    //Db context is de database
    public partial class Model1 : DbContext
    {
        //geef met de base constructor de naam van de connectiestring in app.config
        public Model1()
            : base("name=studenten")
        {
        }

        //dit komt overeen met de tabel Student, elke rij is een object van het type Student
        public virtual DbSet<Student> Student { get; set; }

        //Geeft extra constraints weer over de database structuur
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // naam geen unicode karakters kan bevatten
            modelBuilder.Entity<Student>()
                .Property(e => e.Naam)
                .IsUnicode(false);

            //score een vaste lengte heeft (let op dit was geen int in de database)
            modelBuilder.Entity<Student>()
                .Property(e => e.Score)
                .IsFixedLength();
        }
    }
}
