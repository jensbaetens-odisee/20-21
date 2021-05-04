using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Les2
{
    public class Numbers
    {
        private List<int> Lijst;

        public Numbers(List<int> lijst)
        {
            Lijst = lijst;
        }

        public int SomVanVeelvoudenVanDrie()
        {
            return Lijst.Where(x => x % 3 == 0).Sum();
        }
    }
}
