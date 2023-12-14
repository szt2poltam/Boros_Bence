using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fuvar
{
    class taxi
    {
        public int id { get; private set; }
        public DateTime idopont { get; private set; }
        public int uthossz { get; private set; }
        public double tavolsag { get; private set; }
        public double viteldij { get; private set; }
        public double borravalo { get; private set; }
        public string fizetesmod { get; private set; }

        public taxi(string sor)
        {
            string[] m = sor.Split(";");
            id = int.Parse(m[0]);
            idopont = DateTime.Parse(m[1]);
            uthossz = int.Parse(m[2]);
            tavolsag = double.Parse(m[3]);
            viteldij = double.Parse(m[4]);
            borravalo = double.Parse(m[5]);
            fizetesmod = m[6];
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                StreamReader fajl = new StreamReader("fuvar.csv");
                List<taxi> list = new List<taxi>();
                fajl.ReadLine();
                string sor = "";
                while (!fajl.EndOfStream)
                {
                    sor = fajl.ReadLine();
                    list.Add(new taxi(sor));
                }
                fajl.Close();
                Console.WriteLine("3. feladat: {0} fuvar", list.Count);


                var f = list.Where(b => b.id == 6185).Sum(b => b.viteldij + b.borravalo);
                int db = 0;
                foreach (var item in list)
                {
                    if (item.id == 6185)
                    {
                        db++;
                    }
                }



                Console.WriteLine("4. feladat: {0} fuvar alatt: {1}$", db, f);
                Console.WriteLine("5. feladat:");

                var d = list.GroupBy(b => b.fizetesmod);
                foreach (var item in d)
                {
                    Console.WriteLine($"        {item.Key} - {item.Count()}");
                }

                var l = list.Sum(b => b.tavolsag * 1.6f);

                Console.WriteLine("6. feladat: {0}", Math.Round(l, 2) + "km");
                Console.WriteLine("7. feladat: Leghosszabb fuvar:");
                var j = list.OrderByDescending(b => b.uthossz).First();

                Console.WriteLine("        Fuvar hossza: {0} másodperc \n        Id: {1} \n        Megtett távolság: {2} km\n        Viteldíj: {3}$", j.uthossz, j.id, j.tavolsag, j.viteldij + j.borravalo);









                Console.ReadKey();
            }
        }
    }
}