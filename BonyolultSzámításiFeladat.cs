using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUARC6_FF
{
    class BonyolultSzámításiFeladat : SzámításiFeladat
    {
        public BonyolultSzámításiFeladat(string feladat_neve) : base(feladat_neve)
        {
            időigény = r.Next(3, 11);
            prioritás = r.Next(3, 9);
        }
        public BonyolultSzámításiFeladat(string feladat_neve, int időigény, int prioritás) : base(feladat_neve, időigény, prioritás)
        {
            this.prioritás = prioritás;
            this.időigény = időigény;
            this.feladat_neve = feladat_neve;
        }
    }
}
