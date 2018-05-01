using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUARC6_FF
{
    class TúlSokKörÓtaÉlException : Exception
    {
        IFeladat hiba;
        public IFeladat Hiba { get { return hiba; } }
        public TúlSokKörÓtaÉlException(IFeladat k) : base("Ez az elem túl sok kör óta él már a feladatok között: ")
        {
            hiba = k;
        }
    }
}
