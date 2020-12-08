using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tomi_2020._11._26_eutazas
{
    class Program
    {
        struct Adat
        {
            public int megallo;
            public int datum;
            public int ido;
            public int azonosito;
            public string tipus;
            public int datumervenyesseg;
        }
        static void Main(string[] args)
        {
            Adat[] adatok = new Adat[2000];
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Downloads\utasadat.txt");
            int n = 0;
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] db = sor.Split();
                adatok[n].megallo = int.Parse(db[0]);
                string[] tomb = db[1].Split('-');
                adatok[n].datum = int.Parse(tomb[0]);
                adatok[n].ido = int.Parse(tomb[1]);
                adatok[n].azonosito = int.Parse(db[2]);
                adatok[n].tipus = db[3];
                adatok[n].datumervenyesseg = int.Parse(db[4]);
                n++;
            }
            olvas.Close();

            //2.feladat
            Console.WriteLine($"2.Feladat:\nA buszra {n} utas akart felszállni.");

            //3.feladat
            int kettes = 0;
            for (int i = 0; i < n; i++)
            {
                if (adatok[i].datumervenyesseg == 0)
                {
                    kettes++;
                }
                else if (adatok[i].datumervenyesseg > 11 && adatok[i].datumervenyesseg < adatok[i].datum)
                {
                    kettes++;
                }
            }
            Console.WriteLine($"3.Feladat:\nA buszra {kettes} utas nem szállhatott fel.");
            int legtobb = 0;
            int megall = 0;
            int u = 0;
            for (int i = 0; i < n - 1; i++)
            {

                if (adatok[i].megallo == adatok[i + 1].megallo)
                {
                    u++;
                }
                else
                {
                    u++;
                    if (legtobb < u)
                    {
                        legtobb = u;
                        megall = adatok[i].megallo;
                    }
                    u = 0;
                }
            }
            Console.WriteLine($"4.Feladat\nA legtöbb utas ({legtobb} fő) a {megall}.megállóban probált felszállni.");

            //5.feladat
            int z = 0;
            int t = 0;
            for (int i = 0; i < n; i++)
            {
                if (adatok[i].datumervenyesseg >= adatok[i].datum)
                {
                    if (adatok[i].tipus == "TAB" || adatok[i].tipus == "NYB")
                    {
                        z++;
                    }
                    if (adatok[i].tipus == "NYP" || adatok[i].tipus == "RVS" || adatok[i].tipus == "GYK")
                    {
                        t++;
                    }
                }
            }
            Console.WriteLine($"5.Feladat:\nIngyenesen utazók száma: {t}\n Kedvezményesen utazók száma: {z} ");

            //7.feladat
            StreamWriter ir = new StreamWriter(@"C:\Users\Rendszergazda\Downloads\figyelmeztetes.txt");
            for (int i =0; i<n;i++)
            {
                if (adatok[i].datumervenyesseg>10)
                {
                    int ev2 = int.Parse(adatok[i].datumervenyesseg.ToString().Substring(0, 4));
                    int ev1 = int.Parse(adatok[i].datum.ToString().Substring(0, 4));
                    int ho2 = int.Parse(adatok[i].datumervenyesseg.ToString().Substring(4, 2));
                    int ho1 = int.Parse(adatok[i].datum.ToString().Substring(4, 2));
                    int nap2 = int.Parse(adatok[i].datumervenyesseg.ToString().Substring(6, 2));
                    int nap1 = int.Parse(adatok[i].datum.ToString().Substring(6, 2));
                    if (napokszama(ev1, ho1, nap1, ev2, ho2, nap2) <= 3)
                    {
                        ir.WriteLine($"{adatok[i].azonosito} {ev2}-{ho2.ToString("00")}-{nap2.ToString("00")}");
                    }
                }
            }
            ir.Close();
            Console.ReadKey();
        }

        //6.feladat: függvény
        static int napokszama(int e1, int h1, int n1, int e2, int h2, int n2)
        {
            h1 = (h1 + 9) % 12;
            e1 = e1 - h1 / 10;
            int d1 = 365 * e1 + e1 / 4 - e1 / 100 + e1 / 400 + (h1 * 306 + 5) / 10 + n1 - 1;
            h2 = (h2 + 9) % 12;
            e2 = e2 - h2 / 10;
            int d2 = 365 * e2 + e2 / 4 - e2 / 100 + e2 / 400 + (h2 * 306 + 5) / 10 + n2 - 1;
            return (d2 - d1);
        }
    }
}
