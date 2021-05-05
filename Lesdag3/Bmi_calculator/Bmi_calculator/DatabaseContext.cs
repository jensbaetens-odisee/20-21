using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmi_calculator
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("bmiConn")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BMI> BMIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BMI>()
                .HasKey(bmi => new { bmi.Date, bmi.UserId });

            //modelBuilder.Entity<BMI>().HasMany<User>(bmi => bmi.User);
        }
    }
}
