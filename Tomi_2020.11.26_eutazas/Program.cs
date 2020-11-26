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
            while(!olvas.EndOfStream)
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
                else if (adatok[i].datumervenyesseg>11 && adatok[i].datumervenyesseg < adatok[i].datum)
                {
                    kettes++;
                }
            }
            Console.WriteLine($"3.Feladat:\nA buszra {kettes} utas nem szállhatott fel.");
            int legtobb = 0;
            int megall = 0;
            int u = 0;
            for (int i =0;i<n-1;i++)
            {
                
                if (adatok[i].megallo == adatok[i+1].megallo)
                {
                    u++;
                }
                else
                {
                    u++;
                    if (legtobb<u)
                    {
                        legtobb = u;
                        megall = adatok[i].megallo;
                    }
                    u = 0;
                }
            }
            Console.WriteLine($"4.Feladat\nA legtöbb utas ({legtobb} fő) a {megall}.megállóban probált felszállni.");
            Console.ReadKey();
        }
    }
}
