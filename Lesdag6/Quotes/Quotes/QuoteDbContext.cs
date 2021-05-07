using Quotes.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotes
{
    public class QuoteDbContext: DbContext
    {
        public QuoteDbContext():base("quotes")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<QuoteDbContext, Configuration>());
        }


        public virtual DbSet<Quote> Quotes { get; set; }
    }
}
