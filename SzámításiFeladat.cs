using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUARC6_FF
{
    abstract class SzámításiFeladat : IFeladat
    {
        protected int időigény;
        protected int prioritás;
        protected int kör;
        protected string feladat_neve;
        IFeladat következő;
        protected static Random r = new Random();
        public IFeladat Következő { get { return következő; } set { következő = value; } }
        public string Feladat_neve { get { return feladat_neve; } }
        public int Időigény { get { return időigény; } set { időigény = value; } }
        public int Prioritás { get { return prioritás; } set { prioritás = value; } }
        public event FeladatBeütemezve Ütemezés;
        public int HánySzimulációsKörÓtaÉl { get { return kör; } }
        public void KörNövel()
        {
            kör++;
        }
        public SzámításiFeladat(string feladat_neve)
        {
            this.feladat_neve = feladat_neve;
            kör = 0;
        }
        public SzámításiFeladat (string feladat_neve, int időigény, int prioritás)
	    {
            this.feladat_neve = feladat_neve;
            this.prioritás = prioritás;
            this.időigény = időigény;
            kör = 0;
	    }
        public void Beütemezve()
        {
            Ütemezés(feladat_neve, kör);
        }
    }
}
