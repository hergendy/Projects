using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUARC6_FF
{
    class NincsIlyenElemException :Exception
    {
        public NincsIlyenElemException() : base("Nem található a keresett elem!")
        {

        }
    }
}
