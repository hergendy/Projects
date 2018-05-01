using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUARC6_FF
{
    interface IFeladat
    {
        string Feladat_neve { get; }
        int Prioritás { get; }
        int Időigény { get; }
        int HánySzimulációsKörÓtaÉl { get; }
        void KörNövel();
        IFeladat Következő { get; set; }
        event FeladatBeütemezve Ütemezés;
        void Beütemezve();
    }
} 