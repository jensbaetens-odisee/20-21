using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry
{
    public class RegistryDbContext : DbContext
    {
        public static string ConnString = "";
        public RegistryDbContext()
            : base(ConnString)
        {

        }

        public virtual DbSet<Bezoeker> Bezoekers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
