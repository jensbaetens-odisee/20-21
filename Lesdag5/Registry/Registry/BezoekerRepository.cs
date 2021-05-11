using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry
{
    public interface IBezoekerRepository
    {
        void AddBezoeker(Bezoeker bezoeker);
        List<Bezoeker> GetBezoekers();
        void UpdateBezoeker(Bezoeker bezoeker);
        void DeleteBezoeker(Bezoeker bezoeker);
    }

    class BezoekerRepository : IBezoekerRepository
    {
        private RegistryDbContext context = new RegistryDbContext();

        public void AddBezoeker(Bezoeker bezoeker)
        {
            context.Bezoekers.Add(bezoeker);
            context.SaveChanges();
        }

        public List<Bezoeker> GetBezoekers()
        {
            return context.Bezoekers.ToList();
        }

        public void UpdateBezoeker(Bezoeker bezoeker)
        {
            context.SaveChanges();
        }

        public void DeleteBezoeker(Bezoeker bezoeker)
        {
            context.Bezoekers.Remove(bezoeker);
            context.SaveChanges();
        }


    }
}
