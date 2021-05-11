using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Tests
{
    public class BezoekerRepositoryFake : IBezoekerRepository
    {
        public List<Bezoeker> bezoekers = new List<Bezoeker>(){ };

        void AddBezoeker(Bezoeker bezoeker)
        {
            bezoekers.Add(bezoeker);

        }
        List<Bezoeker> GetBezoekers()
        {
            return bezoekers;
        }
        void UpdateBezoeker(Bezoeker bezoeker)
        {

        }
        void DeleteBezoeker(Bezoeker bezoeker)
        {

        }
    }
}
