using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUARC6_FF
{
    class CPUFeladatÜtemező
    {
        int időkapacitás;
        int ciklus;
        int Időkapacitás { get { return időkapacitás; } }
        bool túlSok = false;
        public bool TúlSok { get { return túlSok; } }
        static Random r = new Random();

        FeladatLista fl = new FeladatLista();

        public CPUFeladatÜtemező(int időkapacitás, int ciklus)
        {
            this.időkapacitás = időkapacitás;
            this.ciklus = ciklus;
            fl.SokKör += TúlSokKör;
        }

        public void ListaLétrehozás()
        {
            FeladatLista fl = new FeladatLista();
        }

        public bool ÜresLista()
        {
            return fl.Fej == null;
        }
        public void TúlSokKör()
        {
            túlSok = true;
        }

        public void ListaFeltöltés(IFeladat feladat)
        {
            try
            {
                fl.RendezettFeladatHozzáadás(feladat);
            }
            catch (MárVanIlyenElemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CiklusFuttatás()
        {
            string[] Ered = fl.FeladatÖsszeállítás(Időkapacitás);
            for (int i = 0; i < Ered.Length; i++)
            {
                if (Ered[i] == null)
                    break;
                try
                {
                    fl.MegadottElemTörlés(Ered[i]);
                }
                catch (NincsIlyenElemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            try
            {
                fl.KörNövelése(ciklus);
            }
            catch(TúlSokKörÓtaÉlException e)
            {
                IFeladat k = e.Hiba;
                while (k != null)
                {
                    Console.WriteLine(e.Message + k.Feladat_neve);
                    k = k.Következő;
                }
            }
        }
    }
}
