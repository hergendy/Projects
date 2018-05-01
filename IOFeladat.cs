using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUARC6_FF
{
    public delegate void FeladatBeütemezve(string nev, int kör);
    abstract class IOFeladat : IFeladat
    {
        protected int időigény;
        protected int prioritás;
        protected int kör;
        protected string feladat_neve;
        IFeladat következő;
        protected static Random r = new Random();
        public IFeladat Következő { get { return következő; } set { következő = value; } }
        public string Feladat_neve { get { return feladat_neve; } }
        public int Időigény { get { return időigény; } }
        public int Prioritás { get { return prioritás; } }
        public int HánySzimulációsKörÓtaÉl { get { return kör; } }
        public event FeladatBeütemezve Ütemezés;
        public void KörNövel()
        {
            kör++;
        }
        public IOFeladat(string feladat_neve)
        {
            this.feladat_neve = feladat_neve;
            kör = 0;
        }
        public IOFeladat (string feladat_neve, int időigény, int prioritás)
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
