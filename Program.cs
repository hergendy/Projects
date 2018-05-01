using System;
using System.IO;

namespace ZUARC6_FF
{
    class Program
    {
        static void Main(string[] args)
        {
            CPUFeladatÜtemező CPU;
            using (StreamReader sr = new StreamReader("Bemenet.txt"))
            {
                int idő = 0;
                int ciklus = 0;
                string kar = sr.ReadLine();
                int k = 0;
                while (kar[k] != 44)
                {
                    if (idő != 0)
                        idő = idő * 10;
                    idő += kar[k] - 48;
                    k++;
                }
                k++;
                while (k < kar.Length && kar[k] != 44)
                {
                    if (ciklus != 0)
                        ciklus = ciklus * 10;
                    ciklus += kar[k] - 48;
                    k++;
                }
                    
                CPU = new CPUFeladatÜtemező(idő, ciklus);

                CPU.ListaLétrehozás();

                string line;
                int ido = 0;
                int prio = 0;
                string tipus = "";
                string nev = "";
                while ((line = sr.ReadLine()) != null)
                {
                    int i = 0;
                    while (i < line.Length && line[i].ToString() != ",")
                    {
                        tipus += line[i].ToString();
                        i++;
                    }
                    i++;
                    while (i < line.Length && line[i].ToString() != ",")
                    {
                        nev += line[i].ToString();
                        i++;
                    }
                    i++;
                    while (i < line.Length && line[i].ToString() != ",")
                    {
                        ido = line[i]-48;
                        i++;
                    }
                    i++;
                    while (i < line.Length && line[i].ToString() != ",")
                    {
                        prio = line[i]-48;
                        i++;
                    }

                    if (prio == 0)
                    {
                        switch (tipus)
                        {
                            case "soros":
                                SorosPortIO soros = new SorosPortIO(nev);
                                CPU.ListaFeltöltés(soros);
                                soros.Ütemezés += Kiir;
                                break;
                            case "merev":
                                MerevlemezIO merev = new MerevlemezIO(nev);
                                CPU.ListaFeltöltés(merev);
                                merev.Ütemezés += Kiir;
                                break;
                            case "egyszeru":
                                EgyszerűSzámításiFeladat egyszeru = new EgyszerűSzámításiFeladat(nev);
                                CPU.ListaFeltöltés(egyszeru);
                                egyszeru.Ütemezés += Kiir;
                                break;
                            case "bonyolult":
                                BonyolultSzámításiFeladat bonyolult = new BonyolultSzámításiFeladat(nev);
                                CPU.ListaFeltöltés(bonyolult);
                                bonyolult.Ütemezés += Kiir;
                                break;
                        }
                    }
                    else
                    {
                        switch (tipus)
                        {
                            case "soros":
                                SorosPortIO soros = new SorosPortIO(nev, ido, prio);
                                CPU.ListaFeltöltés(soros);
                                soros.Ütemezés += Kiir;
                                break;
                            case "merev":
                                MerevlemezIO merev = new MerevlemezIO(nev, ido, prio);
                                CPU.ListaFeltöltés(merev);
                                merev.Ütemezés += Kiir;
                                break;
                            case "egyszeru":
                                EgyszerűSzámításiFeladat egyszeru = new EgyszerűSzámításiFeladat(nev, ido, prio);
                                CPU.ListaFeltöltés(egyszeru);
                                egyszeru.Ütemezés += Kiir;
                                break;
                            case "bonyolult":
                                BonyolultSzámításiFeladat bonyolult = new BonyolultSzámításiFeladat(nev, ido, prio);
                                CPU.ListaFeltöltés(bonyolult);
                                bonyolult.Ütemezés += Kiir;
                                break;
                        }
                    }
                    tipus = "";
                    nev = "";
                    ido = 0;
                    prio = 0;
                }
            }

            while (!CPU.ÜresLista() && !CPU.TúlSok)
            {
                CPU.CiklusFuttatás();
            }
            
            Console.ReadLine();
        }

        static void Kiir(string feladat_neve, int kör)
        {
            Console.WriteLine("Az " + feladat_neve + " nevű feladat a " + (kör+1) + ". ciklusban lett beütemezve.");
        }
    }
}
