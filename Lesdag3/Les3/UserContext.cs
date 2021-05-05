using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les3
{
    class UserContext : DbContext
    {
        // link user context to the database studenten
        public UserContext()
            :base("studenten")
        {

        }

        //zorgt ervoor dat er tabellen aangemaakt voor de types User en Car
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }

        // doet meer complexe zaken voor configuratie van de databank
        // bvb veel-op-veel relaties toevoegen
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //de veel-op-veel relatie
            modelBuilder.Entity<User>()
                .HasMany<Car>(user => user.Cars)
                .WithMany(car => car.Users);

            modelBuilder.Entity<Car>().Property(car => car.Model)
                .HasMaxLength(50)
                .IsOptional()
                .HasColumnName("Reeks");
        }
    }
}
