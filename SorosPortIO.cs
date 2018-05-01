using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUARC6_FF
{
    class SorosPortIO : IOFeladat
    {
        public SorosPortIO(string feladat_neve) : base(feladat_neve)
        {
            időigény = r.Next(1, 4);
            prioritás = r.Next(1, 4);
            this.feladat_neve = feladat_neve;
        }
        public SorosPortIO(string feladat_neve, int időigény, int prioritás) : base(feladat_neve, időigény, prioritás)
        {
            this.prioritás = prioritás;
            this.időigény = időigény;
            this.feladat_neve = feladat_neve;
        }
    }
}
