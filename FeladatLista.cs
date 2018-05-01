using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUARC6_FF
{
    public delegate void TúlSokKör();
    class FeladatLista
    {
        IFeladat fej;
        static int elemszám = 0;
        public IFeladat Fej { get { return fej; } }
        public int Elemszám { get { return elemszám; } }
        public event TúlSokKör SokKör;

        public FeladatLista()
        {
            fej = null;
        }

        public void RendezettFeladatHozzáadás(IFeladat feladat)
        {
            if (fej == null)
            {
                fej = feladat;
                feladat.Következő = null;
            }
            else
            {
                IFeladat f = fej;
                while (f != null)
                {
                    if (f.Feladat_neve == feladat.Feladat_neve)
                        throw new MárVanIlyenElemException();
                    f = f.Következő;
                }
                f = fej;
                while (f.Következő != null && f.Következő.Prioritás > feladat.Prioritás)
                {
                    f = f.Következő;
                }
                if (f.Következő == null)
                {
                    f.Következő = feladat;
                    feladat.Következő = null;
                }
                else
                {
                    IFeladat p = f.Következő, e = f;
                    while (p != null && feladat.Időigény < p.Időigény)
                    {
                        e = p;
                        p = p.Következő;
                    }
                    if (p == null)
                    {
                        feladat.Következő = null;
                        e.Következő = feladat;
                    }
                    else
                    {
                        while (p != null && p.Prioritás == feladat.Prioritás && feladat.Időigény > p.Időigény)
                        {
                            e = p;
                            p = p.Következő;
                        }
                        if (e == null)
                        {
                            feladat.Következő = fej;
                            fej = feladat;
                        }
                        else
                        {
                            feladat.Következő = p;
                            e.Következő = feladat;
                        }
                    }
                }
            }
            elemszám++;
        }

        public void MegadottElemTörlés(string nev)
        {
            IFeladat seged = null;
            IFeladat k = fej;
            while (k != null && nev != k.Feladat_neve)
            {
                seged = k;
                k = k.Következő;
            }
            if (k == null)
                throw new NincsIlyenElemException();
            if (k == fej)
            {
                k.Beütemezve();
                fej = k.Következő;
            }
            else
            {
                k.Beütemezve();
                seged.Következő = k.Következő;
                seged = k;
            }
            elemszám--;
        }

        public void BackTrack(IFeladat k, int idő, int szint, ref int max, ref int maxidő, int opt, int optidő, ref string[] E, ref string[] F)
        {
            while (k != null && optidő != idő)
            {
                if (k.Időigény + optidő <= idő)
                {
                    int j = szint + 1;
                    while (j < F.Length && F[j] != null)
                    {
                        F[j] = null;
                        j++;
                    }
                    F[szint] = k.Feladat_neve;
                    opt += k.Prioritás;
                    optidő += k.Időigény;
                    BackTrack(k.Következő, idő, szint + 1, ref max, ref maxidő, opt, optidő, ref E, ref F);
                    if (optidő > maxidő || (optidő == maxidő && opt > max))
                    {
                        max = opt;
                        maxidő = optidő;
                        int i = 0;
                        while (E[i] != null)
                        {
                            E[i] = null;
                            i++;
                        }
                        i = 0;
                        while (i <= szint)
                        {
                            E[i] = F[i];
                            i++;
                        }
                    }
                }
                int l = szint + 1;
                if (l < F.Length && F[l] != null)
                {
                    F[l] = null;
                    l++;
                }
                if (k != null)
                {
                    k = k.Következő;
                }
            }
        }

        public string[] FeladatÖsszeállítás(int idő)
        {
            string[] E = new string[Elemszám];
            string[] F = new string[Elemszám];
            IFeladat k = fej;
            int max = 0, maxidő = 0;
            BackTrack(k, idő, 0, ref max, ref maxidő, 0, 0, ref E, ref F);
            return E;
        }

        public void KörNövelése(int ciklus)
        {
            IFeladat k = fej;
            while (k != null)
            {
                k.KörNövel();
                if (k.HánySzimulációsKörÓtaÉl >= ciklus)
                {
                    SokKör();
                    throw new TúlSokKörÓtaÉlException(k);
                }
                k = k.Következő;
            }
        }
    }
}
