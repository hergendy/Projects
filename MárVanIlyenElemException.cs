using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUARC6_FF
{
    class MárVanIlyenElemException : Exception
    {
        public MárVanIlyenElemException() : base("Már van egy ilyen elem a listában.")
        {

        }
    }
}
